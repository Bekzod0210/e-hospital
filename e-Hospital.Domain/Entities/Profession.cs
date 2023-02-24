namespace e_Hospital.Domain.Entities
{
    public class Profession
    {
        public Profession()
        {
            Employees = new List<Employee>();
            Queues = new List<Queue>();
        }

        public int Id { get; set; }
        public string Name { get; set; }


        public ICollection<Employee> Employees { get; set; }
        public ICollection<Queue> Queues { get; set; }
    }
}
