using Back.Dtos;
using Back.Models;
using Back.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Back.Patterns;
public class DoctorRegistrationStrategy : IRoleRegistrationStrategy
{
    private readonly Context context;
    public DoctorRegistrationStrategy(Context context)
    {
        this.context = context;
    }
    public async Task<bool> RegistrRoleAsync(object dto)
    {
        var model = dto as DoctorRegistrationDTO;
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
        PostDoctorDTO postDoctorDTO = new()
        {
            UserId = user.Id,
            SpecializationId = model!.SpecializationId,
            TimeOfTaking = model!.TimeOfTaking,
            FIO = model!.FIO
        };
        DoctorEntity doctor = postDoctorDTO.ToDoctorEntity();
        await context.Doctors.AddAsync(doctor);
        await context.SaveChangesAsync();
        return true;
    }
}