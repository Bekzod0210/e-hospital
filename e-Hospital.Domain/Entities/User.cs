using e_Hospital.Domain.Enums;

namespace e_Hospital.Domain.Entities
{
    public class User
    {
        public User()
        {
            Dieds = new HashSet<Died>();
            Borns = new HashSet<Born>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }

        public ICollection<Died> Dieds { get; set; }
        public ICollection<Born> Borns { get; set; }
    }
}
