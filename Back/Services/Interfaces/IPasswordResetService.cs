namespace Back.Services;

public interface IPasswordResetService
{
    Task<string> CreateResetCode(int userId);
    Task<bool> VerifyResetCode(int userId, string code);
}