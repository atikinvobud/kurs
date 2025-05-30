using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Back.Models;

public class SickLeaveConfiguration : IEntityTypeConfiguration<SickLeaveEntity>
{
    public void Configure(EntityTypeBuilder<SickLeaveEntity> builder)
    {
        builder.HasKey(sl => sl.Id);

        builder.HasOne(sl => sl.medicalCardEntity)
            .WithMany(mc => mc.sickLeaveEntities)
            .HasForeignKey(sl => sl.MedicalCardId);

        builder.HasOne(sl => sl.doctorEntity)
            .WithMany(d => d.sickLeaveEntities)
            .HasForeignKey(sl => sl.DoctorId);
    }
}