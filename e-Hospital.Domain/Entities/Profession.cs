namespace e_Hospital.Domain.Entities
{
    public class Profession
    {
        public Profession()
        {
            Employees = new List<Employee>();
            Queues = new Queue<Queue>();
        }

        public int Id { get; set; }
        public string Name { get; set; }


        public ICollection<Employee> Employees { get; set; }
        public Queue<Queue> Queues { get; set; }
    }
}
