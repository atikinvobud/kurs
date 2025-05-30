using Back.Models;

namespace Back.Dtos;

public class AuthResult
{
    public string MainPage { get; set; } = null!;
    public List<string> AllowedPages { get; set; } = new();
    public UserEntity User { get; set; } = null!;
}
