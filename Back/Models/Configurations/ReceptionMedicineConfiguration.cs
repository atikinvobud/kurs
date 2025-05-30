using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Back.Models;

public class ReceptionMedicineConfiguration : IEntityTypeConfiguration<ReceptionMedicineEntity>
{
    public void Configure(EntityTypeBuilder<ReceptionMedicineEntity> builder)
    {
        builder.HasKey(rm => rm.Id);

        builder.HasOne(rm => rm.medicineEntity)
            .WithMany(m => m.receptionMedicineEntities)
            .HasForeignKey(rm => rm.MedicineId);

        builder.HasOne(rm => rm.receptionEntity)
            .WithMany(r => r.receptionMedicineEntities)
            .HasForeignKey(rm => rm.ReceptionId);
    }
}