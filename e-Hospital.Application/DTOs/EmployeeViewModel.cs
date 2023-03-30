using System.ComponentModel.DataAnnotations;

namespace e_Hospital.Application.DTOs
{
    public class EmployeeViewModel
    {
        public string? Name { get; set; }

        public string? PhoneNumber { get; set; }

        public int? ProfessionId { get; set; }
    }
}
