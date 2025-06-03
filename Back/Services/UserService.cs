using System.Threading.Tasks;
using Back.Dtos;
using Back.Models;
using Microsoft.EntityFrameworkCore;

namespace Back.Services;

public class UserService : IUserService
{
    private readonly Context context;
    public UserService(Context context)
    {
        this.context = context;
    }
    public async Task<UserEntity?> FindUserByLogin(string login)
    {
        List<UserEntity> users = await context.Users.ToListAsync();
        List<UserEntity> usersLogin = users.Where(u => u.Login == login).ToList();
        if (users.Count == 0) return null;
        return usersLogin[0];
    }

    public async Task<bool> Update(string Password, int Id)
    {
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<GetUserDTO> GetPersonalInfo(int userId)
    {
        GetUserDTO? user = await context.Users.Where(u => u.Id == userId).Include(u => u.patientEntity)
        .Select(u => new GetUserDTO()
        {
            Id = u.Id,
            Fio = u.patientEntity!.FIO,
            DateofBirth = u.DateOfBirth
        }).FirstOrDefaultAsync();
        if (user == null) return null!;
        return user!;
    }
}