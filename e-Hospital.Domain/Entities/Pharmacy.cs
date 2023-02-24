namespace e_Hospital.Domain.Entities
{
    public class Pharmacy
    {
        public Pharmacy()
        {
            PharmacyMedicines = new HashSet<PharmacyMedicine>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }


        public ICollection<PharmacyMedicine> PharmacyMedicines { get; set; }
    }
}
