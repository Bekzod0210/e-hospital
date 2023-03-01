namespace e_Hospital.Domain.Entities
{
    public class Patient : User
    {
        public Patient()
        {
            Orders = new HashSet<Order>();
            Queues = new HashSet<Queue>();
            MedicalExamination = new HashSet<MedicalExaminationResult>();
        }
        public int MedicalExaminationId { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<Queue> Queues { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<MedicalExaminationResult> MedicalExamination { get; set; }
    }
}
