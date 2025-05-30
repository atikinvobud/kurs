using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Back.Models;

public class ScheduleConfiguration : IEntityTypeConfiguration<ScheduleEntity>
{
    public void Configure(EntityTypeBuilder<ScheduleEntity> builder)
    {
        builder.HasKey(s => s.Id);

        builder.HasOne(s => s.appointmentEntity)
            .WithOne(a => a.scheduleEntity)
            .HasForeignKey<ScheduleEntity>(s => s.AppointmentId);

        builder.HasOne(s => s.doctorEntity)
            .WithMany(d => d.scheduleEntities)
            .HasForeignKey(s => s.DoctorId);

        builder.HasOne(s => s.polyclinicEntity)
            .WithMany(p => p.scheduleEntities)
            .HasForeignKey(s => s.PolyclinicId);
    }
}