namespace e_Hospital.Domain.Entities
{
    public class Died
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int HospitalId { get; set; }
        public DateTime Date { get; set; }


        public User User { get; set; }
        public Hospital Hospital { get; set; }
    }
}
