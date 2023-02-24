namespace e_Hospital.Domain.Entities
{
    public class Born
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public int HospitalId { get; set; }
        public int UserId { get; set; }


        public Hospital Hospital { get; set; }
        public User User { get; set; }
    }
}
