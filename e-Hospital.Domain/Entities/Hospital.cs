namespace e_Hospital.Domain.Entities
{
    public class Hospital
    {
        public Hospital()
        {
            HospitalEmployees = new HashSet<HospitalEmployee>();
            Ambulances = new HashSet<Ambulance>();
            Queues = new HashSet<Queue>();
            Dieds = new HashSet<Died>();
            Borns = new HashSet<Born>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public ICollection<HospitalEmployee> HospitalEmployees { get; set; }
        public ICollection<Ambulance> Ambulances { get; set; }
        public ICollection<Queue> Queues { get; set; }
        public ICollection<Died> Dieds { get; set; }
        public ICollection<Born> Borns { get; set; }
    }
}
