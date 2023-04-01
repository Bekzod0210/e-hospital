namespace e_Hospital.Application.DTOs
{
    public class QueueViewModel
    {
        public int Id { get; set; }
        public int HospitalId { get; set; }
        public int ProfessionId { get; set; }
        public DateTime DateTime { get; set; }
    }
}
