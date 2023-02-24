namespace e_Hospital.Domain.Entities
{
    public class MedicalExaminationResult
    {
        public int Id { get; set; }
        public int QueueId { get; }
        public string Description { get; set; }


        public Queue Queue { get; set; }
    }
}
