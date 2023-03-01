using e_Hospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_Hospital.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class EmployeeEntityTypeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");

            builder.Property(p => p.Name)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(p => p.PhoneNumber)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasOne(x => x.Profession)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.ProfessionId);
        }
    }
}
