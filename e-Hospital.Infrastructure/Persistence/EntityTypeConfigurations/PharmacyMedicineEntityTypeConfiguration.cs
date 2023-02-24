using e_Hospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_Hospital.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class PharmacyMedicineEntityTypeConfiguration : IEntityTypeConfiguration<PharmacyMedicine>
    {
        public void Configure(EntityTypeBuilder<PharmacyMedicine> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(x => x.Medicine)
                .WithMany(x => x.PharmacyMedicines)
                .HasForeignKey(x => x.MedicineId);

            builder.HasOne(x => x.Pharmacy)
                .WithMany(x => x.PharmacyMedicines)
                .HasForeignKey(x => x.PharmacyId);
        }
    }
}
