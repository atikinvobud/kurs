using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Back.Models;

public class DistinctConfiguration : IEntityTypeConfiguration<DistinctEntity>
{
    public void Configure(EntityTypeBuilder<DistinctEntity> builder)
    {
        builder.HasKey(d => d.Id);

        builder.HasMany(d => d.polyclinicEntities)
            .WithOne(p => p.distinctEntity);
    }
}