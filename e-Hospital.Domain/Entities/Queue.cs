﻿namespace e_Hospital.Domain.Entities
{
    public class Queue
    {
        public Queue()
        {
            MedicalExaminationResults = new HashSet<MedicalExaminationResult>();
        }

        public int Id { get; set; }
        public int PatientId { get; set; }
        public int HospitalId { get; set; }
        public int ProfessionId { get; set; }
        public DateTime Date { get; set; }


        public Patient Patient { get; set; }
        public Hospital Hospital { get; set; }
        public Profession Profession { get; set; }

        public ICollection<MedicalExaminationResult> MedicalExaminationResults { get; set; }
    }
}
