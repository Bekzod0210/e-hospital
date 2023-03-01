using e_Hospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace e_Hospital.Application
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Queue> Queues { get; set; }
        DbSet<Hospital> Hospitals { get; set; }
        DbSet<Employee> Employees { get; set; }
        DbSet<Medicine> Medicines { get; set; }
        DbSet<Ambulance> Ambulances { get; set; }
        DbSet<Profession> Professions { get; set; }
        DbSet<OrderDetail> OrdersDetails { get; set; }
        DbSet<Pharmacy> Pharmacies { get; set; }
        DbSet<HospitalEmployee> HospitalEmployees { get; set; }
        DbSet<PharmacyMedicine> PharmacyMedicines { get; set; }
        DbSet<Born> Bornes { get; set; }
        DbSet<Died> Dieds { get; set; }
        DbSet<Call> Calls { get; set; }
        DbSet<Admin> Admins { get; set; }
        DbSet<Patient> Patients { get; set; }
        DbSet<MedicalExaminationResult> MedicalExaminationResults { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
