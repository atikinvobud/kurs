using Back.Models;

namespace Back.Patterns;

public interface IRoleRegistrationStrategy
{
    Task<bool> RegistrRoleAsync(object dto);
}