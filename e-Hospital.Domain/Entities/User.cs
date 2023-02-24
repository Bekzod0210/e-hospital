namespace e_Hospital.Domain.Entities
{
    public class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
            Queues = new HashSet<Queue>();
            Dieds = new HashSet<Died>();
            Borns = new HashSet<Born>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }


        public ICollection<Order> Orders { get; set; }
        public ICollection<Queue> Queues { get; set; }
        public ICollection<Died> Dieds { get; set; }
        public ICollection<Born> Borns { get; set; }
    }
}
