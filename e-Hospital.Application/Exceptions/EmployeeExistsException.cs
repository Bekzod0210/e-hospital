namespace e_Hospital.Application.Exceptions
{
    public class HospitalExistsException : Exception
    {
        private const string _message = "Hospital Exists!";

        public HospitalExistsException() : base(_message) { }
    }
}
