using e_Hospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_Hospital.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(x => x.Patient)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.PatientId);
        }
    }
}
