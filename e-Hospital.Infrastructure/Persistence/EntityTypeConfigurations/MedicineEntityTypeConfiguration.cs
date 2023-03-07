using e_Hospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace e_Hospital.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class MedicineEntityTypeConfiguration : IEntityTypeConfiguration<Medicine>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Medicine> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(p => p.CreateDate)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(p => p.EndDate)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(p => p.Status)
                .IsRequired();
        }
    }
}
