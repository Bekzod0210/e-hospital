using e_Hospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_Hospital.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class HospitalEmployeeEntityTypeConfiguration : IEntityTypeConfiguration<HospitalEmployee>
    {
        public void Configure(EntityTypeBuilder<HospitalEmployee> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(x => x.Employee)
                .WithMany(x => x.EmployeeHospitals)
                .HasForeignKey(x => x.EmployeeId);

            builder.HasOne(x => x.Hospital)
                .WithMany(x => x.HospitalEmployees)
                .HasForeignKey(x => x.HospitalId);
        }
    }
}
