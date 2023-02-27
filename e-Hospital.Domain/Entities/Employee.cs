using e_Hospital.Domain.Enums;

namespace e_Hospital.Domain.Entities
{
    public class Employee
    {
        public Employee()
        {
            EmployeeHospitals = new HashSet<HospitalEmployee>();
        }

        public int Id { get; set; }
        public int ProfessionId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }


        public Profession Profession { get; set; }
        public ICollection<HospitalEmployee> EmployeeHospitals { get; set; }
    }
}
