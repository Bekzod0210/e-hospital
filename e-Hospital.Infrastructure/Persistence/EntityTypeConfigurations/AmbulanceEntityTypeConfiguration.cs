using e_Hospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_Hospital.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class AmbulanceEntityTypeConfiguration : IEntityTypeConfiguration<Ambulance>
    {
        public void Configure(EntityTypeBuilder<Ambulance> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(x => x.Hospital)
                .WithMany(x => x.Ambulances)
                .HasForeignKey(x => x.HospitalId);

            builder.HasOne(x => x.Call)
                .WithMany(x => x.Ambulances)
                .HasForeignKey(x => x.CallId);

        }
    }
}
