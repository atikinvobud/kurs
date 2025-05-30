using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Back.Models;

public class PolyclinicConfiguration : IEntityTypeConfiguration<PolyclinicEntity>
{
    public void Configure(EntityTypeBuilder<PolyclinicEntity> builder)
    {
        builder.HasKey(p => p.Id);

        builder.HasMany(p => p.doctorPolyclinicEntities)
            .WithOne(dp => dp.polyclinicEntity);

        builder.HasMany(p => p.medicalCardEntities)
            .WithOne(mc => mc.polyclinicEntity);

        builder.HasOne(p => p.registrationOffice)
            .WithOne(ro => ro.polyclinicEntity)
            .HasForeignKey<PolyclinicEntity>(p => p.RegistrationOfficeId);

        builder.HasOne(p => p.distinctEntity)
            .WithMany(d => d.polyclinicEntities)
            .HasForeignKey(p => p.DistinctId);

        builder.HasMany(p => p.scheduleEntities)
            .WithOne(s => s.polyclinicEntity);
    }
}