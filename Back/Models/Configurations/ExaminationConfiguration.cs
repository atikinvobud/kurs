using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Back.Models;

public class ExaminationConfiguration : IEntityTypeConfiguration<ExaminationEntity>
{
    public void Configure(EntityTypeBuilder<ExaminationEntity> builder)
    {
        builder.HasKey(e => e.Id);

        builder.HasOne(e => e.receptionEntity)
            .WithMany(r => r.examinationEntities)
            .HasForeignKey(e => e.ReceptionId);

        builder.HasOne(e => e.specializationEntity)
            .WithMany(s => s.examinationEntities)
            .HasForeignKey(e => e.SpecializationId);
    }
}