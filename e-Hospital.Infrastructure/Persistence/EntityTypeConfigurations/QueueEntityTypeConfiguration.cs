using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Queue = e_Hospital.Domain.Entities.Queue;

namespace e_Hospital.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class QueueEntityTypeConfiguration : IEntityTypeConfiguration<Queue>
    {
        public void Configure(EntityTypeBuilder<Queue> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Queues)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Hospital)
                .WithMany(x => x.Queues)
                .HasForeignKey(x => x.HospitalId);

            builder.HasOne(x => x.Profession)
                .WithMany(x => x.Queues)
                .HasForeignKey(x => x.ProfessionId);
        }
    }
}
