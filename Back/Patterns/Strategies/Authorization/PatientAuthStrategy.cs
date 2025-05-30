using Back.Dtos;
using Back.Models;
using Microsoft.EntityFrameworkCore;

namespace Back.Patterns;
public class PatientAuthStrategy : IAuthStrategy
{
    private readonly Context context;

    public PatientAuthStrategy(Context context)
    {
        this.context = context;
    }
    public async Task<AuthResult?> AuthorizeAsync(LoginDTO dto)
    {
        var user = await context.Users.Include(u => u.patientEntity).FirstOrDefaultAsync(u => u.Login == dto.Login);
        if (user == null) return null;
        bool isPasswordValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.Password);
        if (!isPasswordValid) return null;
        if (user.patientEntity == null) return null;
        return new AuthResult
        {
            User = user,
            MainPage = "PatientHome",
            AllowedPages = new[] { "PatientHome", "Appointments","SelectTime", "MedicalCards","Polyclinics","Login","Registration" }.ToList()
        };
    }
}
