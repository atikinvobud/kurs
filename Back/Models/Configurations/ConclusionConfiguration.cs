using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Back.Models;

public class ConclusionConfiguration : IEntityTypeConfiguration<ConclusionEntity>
{
    public void Configure(EntityTypeBuilder<ConclusionEntity> builder)
    {
        builder.HasKey(c => c.Id);
        builder.HasOne(c => c.appointmentEntity)
            .WithOne(a => a.conclusionEntity);
    }
}