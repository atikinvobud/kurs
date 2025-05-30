using Back.Patterns;
using Back.Dtos;

namespace Back.Services;
public interface IAuthorizationService
{
    Task<IAuthStrategy?> GetStrategyAsync(LoginDTO login);
}