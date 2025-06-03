using Back.Dtos;
using Back.Models;

namespace Back.Services;

public interface IUserService
{
    Task<UserEntity?> FindUserByLogin(string login);
    Task<bool> Update(string Password, int Id);
    Task<GetUserDTO> GetPersonalInfo(int userID);
}