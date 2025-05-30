using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Back.Models;

public class DoctorPolyclinicConfiguration : IEntityTypeConfiguration<DoctorPolyclinicEntity>
{
    public void Configure(EntityTypeBuilder<DoctorPolyclinicEntity> builder)
    {
        builder.HasKey(dp => dp.Id);

        builder.HasOne(dp => dp.doctorEntity)
            .WithMany(d => d.doctorPolyclinics)
            .HasForeignKey(dp => dp.DoctorId);

        builder.HasOne(dp => dp.polyclinicEntity)
            .WithMany(p => p.doctorPolyclinicEntities)
            .HasForeignKey(dp => dp.PolyclinicId);
    }
}