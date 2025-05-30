using Back.Dtos;
using Back.Extensions;
using Back.Models;
using Microsoft.EntityFrameworkCore;

namespace Back.Patterns;

public class RegistrationOfficeRegistrationStrategy : IRoleRegistrationStrategy
{
    private readonly Context context;
    public RegistrationOfficeRegistrationStrategy(Context context)
    {
        this.context = context;
    }
    public async Task<bool> RegistrRoleAsync(object dto)
    {
        var model = dto as RegistrationOfficeDTO;
        UserEntity? usercheck = await context.Users.FirstOrDefaultAsync(u => u.Login == model!.Login);
        if (usercheck != null) return false;
        PostUserDTO postUserDTO = new()
        {
            Login = model!.Login,
            Password = BCrypt.Net.BCrypt.HashPassword(model!.Password),
            DateOfBirth = model!.DateOfBirth
        };
        UserEntity user = postUserDTO.ToEntity();
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        PostRegistrationOfficeDTO postRegistrationOfficeDTO = new()
        {
            UserId = user.Id,
            Address = model!.Address
        };
        RegistrationOfficeEntity office = postRegistrationOfficeDTO.ToOfficeEntity();
        await context.RegistrationOffices.AddAsync(office);
        await context.SaveChangesAsync();
        return true;
    }
}