using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Back.Models;

public class ReceptionConfiguration : IEntityTypeConfiguration<ReceptionEntity>
{
    public void Configure(EntityTypeBuilder<ReceptionEntity> builder)
    {
        builder.HasKey(r => r.Id);

        builder.HasOne(r => r.medicalCardEntity)
            .WithMany(mc => mc.receptionEntities)
            .HasForeignKey(r => r.MedicalCardId);

        builder.HasMany(r => r.examinationEntities)
            .WithOne(e => e.receptionEntity);

        builder.HasMany(r => r.receptionMedicineEntities)
            .WithOne(rm => rm.receptionEntity);
    }
}