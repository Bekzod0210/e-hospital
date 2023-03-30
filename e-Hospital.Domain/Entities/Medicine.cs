using e_Hospital.Domain.Enums;

namespace e_Hospital.Domain.Entities
{
    public class Medicine
    {
        public Medicine()
        {
            PharmacyMedicines = new HashSet<PharmacyMedicine>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EndDate { get; set; }
        public Status Status { get; set; }


        public ICollection<PharmacyMedicine> PharmacyMedicines { get; set; }
    }
}
