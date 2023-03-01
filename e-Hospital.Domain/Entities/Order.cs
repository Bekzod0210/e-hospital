namespace e_Hospital.Domain.Entities
{
    public class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public int PatientId { get; set; }
        public DateTime Date { get; set; }
        public double TotalSum { get; set; }


        public Patient Patient { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
