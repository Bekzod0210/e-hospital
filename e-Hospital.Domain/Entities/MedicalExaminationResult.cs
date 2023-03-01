namespace e_Hospital.Domain.Entities
{
    public class MedicalExaminationResult
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string Description { get; set; }

        public Patient Patient { get; set; }
    }
}
