namespace e_Hospital.Domain.Entities
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int PharmacyMedicineId { get; set; }
        public int Quantity { get; set; }

        public Order Order { get; set; }
        public PharmacyMedicine PharmacyMedicine { get; set; }
    }
}
