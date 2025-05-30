using Back.Dtos;
using Back.Models;
using Microsoft.EntityFrameworkCore;

namespace Back.Patterns;
public class DoctorAuthStrategy : IAuthStrategy
{
    private readonly Context context;

    public DoctorAuthStrategy(Context context)
    {
        this.context = context;
    }
    public async Task<AuthResult?> AuthorizeAsync(LoginDTO dto)
    {
        var user = await context.Users.Include(u => u.doctorEntity).FirstOrDefaultAsync(u => u.Login == dto.Login);
        if (user == null) return null;
        bool isPasswordValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.Password);
        if (!isPasswordValid) return null;
        if (user.doctorEntity == null) return null;
        return new AuthResult
        {
            User = user,
            MainPage = "DoctorHome",
            AllowedPages = new[] { "DoctorHome", "Schedule","Appointment", "Information","Login","Registration"}.ToList()
        };
    }
}
