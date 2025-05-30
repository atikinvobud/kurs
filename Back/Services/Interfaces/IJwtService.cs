using Back.Models;
namespace Back.Services;
public interface IJwtService
{
    string GenerateToken(UserEntity user);
}