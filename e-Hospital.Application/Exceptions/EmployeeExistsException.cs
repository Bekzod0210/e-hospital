namespace e_Hospital.Application.Exceptions
{
    public class EmployeeExistsException : Exception
    {
        private const string _message = "Employee Exists!";

        public EmployeeExistsException() : base(_message) { }
    }
}
