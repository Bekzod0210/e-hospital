﻿namespace e_Hospital.Domain.Entities
{
    public class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
            PharmacyMedicines = new HashSet<PharmacyMedicine>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public double TotalSum { get; set; }


        public User User { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public ICollection<PharmacyMedicine> PharmacyMedicines { get; set; }
    }
}
