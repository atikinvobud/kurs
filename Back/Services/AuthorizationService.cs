using Back.Models;
using Back.Dtos;
using Back.Patterns;
using Microsoft.EntityFrameworkCore;

namespace Back.Services;

public class AuthorizationService : IAuthorizationService
{
    private readonly Context context;
    private readonly IServiceProvider serviceProvider;
    public AuthorizationService(Context context, IServiceProvider serviceProvider)
    {
        this.context = context;
        this.serviceProvider = serviceProvider;
    }

    public async Task<IAuthStrategy?> GetStrategyAsync(LoginDTO login)
    {
        var user = await context.Users
            .Include(u => u.patientEntity)
            .Include(u => u.doctorEntity)
            .Include(u => u.registrationOfficeEntity)
            .FirstOrDefaultAsync(u => u.Login == login.Login);

        if (user == null) return null;
        if (user.patientEntity != null) return serviceProvider.GetService<PatientAuthStrategy>();
        else if (user.doctorEntity != null) return serviceProvider.GetService<DoctorAuthStrategy>();
        else if (user.registrationOfficeEntity != null) return serviceProvider.GetService<OfficeAuthStrategy>();
        return null;
    }
}
