using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Back.Models;

public class RegistrationOfficeConfiguration : IEntityTypeConfiguration<RegistrationOfficeEntity>
{
    public void Configure(EntityTypeBuilder<RegistrationOfficeEntity> builder)
    {
        builder.HasKey(ro => ro.Id);

        builder.HasOne(ro => ro.polyclinicEntity)
            .WithOne(p => p.registrationOffice);

        builder.HasOne(ro => ro.userEntity)
            .WithOne(u => u.registrationOfficeEntity)
            .HasForeignKey<RegistrationOfficeEntity>(ro => ro.UserId);
    }
}