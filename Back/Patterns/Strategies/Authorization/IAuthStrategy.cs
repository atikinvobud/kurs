using Back.Dtos;

namespace Back.Patterns;
public interface IAuthStrategy
{
    Task<AuthResult?> AuthorizeAsync(LoginDTO dto);
}