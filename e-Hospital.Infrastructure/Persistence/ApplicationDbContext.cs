using e_Hospital.Application;
using e_Hospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace e_Hospital.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Queue> Queues { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Ambulance> Ambulances { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<OrderDetail> OrdersDetails { get; set; }
        public DbSet<Pharmacy> Pharmacies { get; set; }
        public DbSet<HospitalEmployee> HospitalEmployees { get; set; }
        public DbSet<PharmacyMedicine> PharmacyMedicines { get; set; }
        public DbSet<Born> Bornes { get; set; }
        public DbSet<Died> Dieds { get; set; }
        public DbSet<Call> Calls { get; set; }
        public DbSet<MedicalExaminationResult> MedicalExaminationResults { get; set; }
        public DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
