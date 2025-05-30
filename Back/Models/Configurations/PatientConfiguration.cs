using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Back.Models;

public class PatientConfiguration : IEntityTypeConfiguration<PatientEntity>
{
    public void Configure(EntityTypeBuilder<PatientEntity> builder)
    {
        builder.HasKey(p => p.Id);

        builder.HasMany(p => p.medicalCardEntities)
            .WithOne(mc => mc.patientEntity);

        builder.HasOne(p => p.userEntity)
            .WithOne(u => u.patientEntity)
            .HasForeignKey<PatientEntity>(p => p.UserId);
    }
}