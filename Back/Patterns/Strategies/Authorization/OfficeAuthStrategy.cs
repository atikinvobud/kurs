using Back.Dtos;
using Back.Models;
using Microsoft.EntityFrameworkCore;

namespace Back.Patterns;
public class OfficeAuthStrategy : IAuthStrategy
{
    private readonly Context context;

    public OfficeAuthStrategy(Context context)
    {
        this.context = context;
    }
    public async Task<AuthResult?> AuthorizeAsync(LoginDTO dto)
    {
        var user = await context.Users.Include(u => u.registrationOfficeEntity).FirstOrDefaultAsync(u => u.Login == dto.Login);
        if (user == null) return null;
        bool isPasswordValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.Password);
        if (!isPasswordValid) return null;
        if (user.registrationOfficeEntity == null) return null;
        return new AuthResult
        {
            User =user,
            MainPage = "DoctorsRegistratura",
            AllowedPages = new[] { "DoctorsRegistratura", "PatientRegistratura","Login","Password"}.ToList()
        };
    }
}
