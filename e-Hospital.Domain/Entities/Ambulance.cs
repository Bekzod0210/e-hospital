namespace e_Hospital.Domain.Entities
{
    public class Ambulance
    {
        public int Id { get; set; }
        public int CallId { get; set; }
        public int HospitalId { get; set; }

        public Call Call { get; set; }
        public Hospital Hospital { get; set; }
    }
}
