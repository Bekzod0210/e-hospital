namespace e_Hospital.Domain.Entities
{
    public class Call
    {
        public Call()
        {
            Ambulances = new List<Ambulance>();
        }

        public int Id { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<Ambulance> Ambulances { get; set; }
    }
}