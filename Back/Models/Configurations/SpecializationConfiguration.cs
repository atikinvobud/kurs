using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Back.Models;

public class SpecializationConfiguration : IEntityTypeConfiguration<SpecializationEntity>
{
    public void Configure(EntityTypeBuilder<SpecializationEntity> builder)
    {
        builder.HasKey(s => s.Id);

        builder.HasMany(s => s.doctorEntities)
            .WithOne(d => d.specializationEntity);

        builder.HasMany(s => s.examinationEntities)
            .WithOne(e => e.specializationEntity);
    }
}