using System.Reflection.Metadata.Ecma335;
using Back.Patterns;

namespace Back.Services;
public class RegistrationService
{
    private readonly IDictionary<string, IRoleRegistrationStrategy> strategies;
    public RegistrationService(IDictionary<string, IRoleRegistrationStrategy> strategies)
    {
        this.strategies = strategies;
    }
    public async Task<bool> RegisterUserAsync(string role, object dto)
    {
        if (!strategies.TryGetValue(role, out var strategy)) throw new Exception("unknownrole");
        return await strategy.RegistrRoleAsync(dto);
    }
}