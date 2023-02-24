namespace e_Hospital.Domain.Entities
{
    public class PharmacyMedicine
    {
        public PharmacyMedicine()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
        public int Id { get; set; }
        public int PharmacyId { get; set; }
        public int MedicineId { get; set; }
        public double Price { get; set; }
        public int Count { get; set;  }

        public Pharmacy Pharmacy { get; set; }
        public Medicine Medicine { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
