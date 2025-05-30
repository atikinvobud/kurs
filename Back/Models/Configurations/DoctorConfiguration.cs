using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Back.Models;

public class DoctorConfiguration : IEntityTypeConfiguration<DoctorEntity>
{
    public void Configure(EntityTypeBuilder<DoctorEntity> builder)
    {
        builder.HasKey(d => d.Id);

        builder.HasMany(d => d.scheduleEntities)
            .WithOne(s => s.doctorEntity);

        builder.HasOne(d => d.userEntity)
            .WithOne(u => u.doctorEntity)
            .HasForeignKey<DoctorEntity>(d => d.UserId);

        builder.HasMany(d => d.doctorPolyclinics)
            .WithOne(dp => dp.doctorEntity);

        builder.HasOne(d => d.specializationEntity)
            .WithMany(s => s.doctorEntities)
            .HasForeignKey(d => d.SpecializationId);

        builder.HasMany( d => d.sickLeaveEntities)
            .WithOne(s => s.doctorEntity);
    }
}