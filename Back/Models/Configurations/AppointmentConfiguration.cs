using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Back.Models;

public class AppointmentConfiguration : IEntityTypeConfiguration<AppointmentEntity>
{
    public void Configure(EntityTypeBuilder<AppointmentEntity> builder)
    {
        builder.HasKey(a => a.Id);

        builder.HasOne(a => a.conclusionEntity)
            .WithOne(c => c.appointmentEntity)
            .HasForeignKey<AppointmentEntity>(a => a.ConclusionId);

        builder.HasOne(a => a.scheduleEntity)
            .WithOne(s => s.appointmentEntity);

        builder.HasOne(a => a.medicalCardEntity)
            .WithMany(mc => mc.appointmentEntities)
            .HasForeignKey(a => a.MedicalCardId);
    }
}