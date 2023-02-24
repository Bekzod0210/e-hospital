namespace e_Hospital.Domain.Entities
{
    public class HospitalEmployee
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int HospitalId { get; set; }

        public Employee Employee { get; set; }
        public Hospital Hospital { get; set; }
    }
}
