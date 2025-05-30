using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Back.Models;

public class MedicineConfiguration : IEntityTypeConfiguration<MedicineEntity>
{
    public void Configure(EntityTypeBuilder<MedicineEntity> builder)
    {
        builder.HasKey(m => m.Id);

        builder.HasMany(m => m.receptionMedicineEntities)
            .WithOne(m => m.medicineEntity);
    }
}