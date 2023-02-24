using e_Hospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_Hospital.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class BornEntityTypeConfigurationm : IEntityTypeConfiguration<Born>
    {
        public void Configure(EntityTypeBuilder<Born> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasMaxLength(30)
                .IsRequired();

            builder.HasOne(x => x.Hospital)
                .WithMany(x => x.Borns)
                .HasForeignKey(x => x.HospitalId);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Borns)
                .HasForeignKey(x => x.UserId);
        }
    }
}
