using e_Hospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_Hospital.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class DiedEntityTypeConfiguration : IEntityTypeConfiguration<Died>
    {
        public void Configure(EntityTypeBuilder<Died> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Dieds)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Hospital)
                .WithMany(x => x.Dieds)
                .HasForeignKey(x => x.HospitalId);
        }
    }
}
