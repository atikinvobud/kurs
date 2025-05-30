using System.Threading.Tasks;
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
        UserEntity? entity = await context.Users.FindAsync(Id);
        if (entity == null) return false;
        entity.Password = Password;
        await context.SaveChangesAsync();
        return true;
    }
}