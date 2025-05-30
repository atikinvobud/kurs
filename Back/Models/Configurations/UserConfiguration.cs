using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Back.Models;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.HasKey(u => u.Id);

        builder.HasOne(u => u.doctorEntity)
            .WithOne(d => d.userEntity);

        builder.HasOne(u => u.patientEntity)
            .WithOne(p => p.userEntity);

        builder.HasOne(u => u.registrationOfficeEntity)
            .WithOne(ro => ro.userEntity);
    }
}