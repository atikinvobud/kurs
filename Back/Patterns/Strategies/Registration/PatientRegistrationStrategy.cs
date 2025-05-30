using Back.Dtos;
using Back.DTOs;
using Back.Models;
using Back.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Back.Patterns;

public class PatientRegistrationStrategy : IRoleRegistrationStrategy
{
    private readonly Context context;
    public PatientRegistrationStrategy(Context context)
    {
        this.context = context;
    }
    public async Task<bool> RegistrRoleAsync(object dto)
    {
        var model = dto as PatientRegistrationDto;
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
        PostPatientDTO postPatientDTO = new()
        {
            UserId = user.Id,
            FIO = model!.FIO
        };
        PatientEntity patient = postPatientDTO.ToPatientEntity();
        await context.Patients.AddAsync(patient);
        await context.SaveChangesAsync();
        return true;
    }
}