using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Back.Models;

public class MedicalCardConfiguration : IEntityTypeConfiguration<MedicalCardEntity>
{
    public void Configure(EntityTypeBuilder<MedicalCardEntity> builder)
    {
        builder.HasKey(mc => mc.Id);

        builder.HasOne(mc => mc.polyclinicEntity)
            .WithMany(p => p.medicalCardEntities)
            .HasForeignKey(mc => mc.PolyclinicId);

        builder.HasOne(mc => mc.patientEntity)
            .WithMany(p => p.medicalCardEntities)
            .HasForeignKey(mc => mc.PatientId);

        builder.HasMany(mc => mc.sickLeaveEntities)
            .WithOne(sl => sl.medicalCardEntity);

        builder.HasMany(mc => mc.receptionEntities)
            .WithOne(r => r.medicalCardEntity);

        builder.HasMany(mc => mc.appointmentEntities)
            .WithOne(a => a.medicalCardEntity);  
    }
}