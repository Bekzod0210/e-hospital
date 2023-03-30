using e_Hospital.Domain.Exceptions;

namespace e_Hospital.Application.Exceptions
{
    public class EmployeeNotFoundException : EntityNotFoundException
    {
        private const string _message = "Employee";

        public EmployeeNotFoundException() : base(_message) { }
    }
}
