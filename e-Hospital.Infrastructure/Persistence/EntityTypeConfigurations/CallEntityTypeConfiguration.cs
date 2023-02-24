using e_Hospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_Hospital.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class CallEntityTypeConfiguration : IEntityTypeConfiguration<Call>
    {
        public void Configure(EntityTypeBuilder<Call> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Address)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.PhoneNumber)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
