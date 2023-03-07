namespace e_Hospital.Application.Exceptions
{
    public class PharmacyExistsException : Exception
    {
        private const string _message = "Pharmacy Exists!";

        public PharmacyExistsException() : base(_message) { }
    }
}


