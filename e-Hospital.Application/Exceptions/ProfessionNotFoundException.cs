namespace e_Hospital.Application.Exceptions
{
    public class ProfessionNotFoundException : Exception
    {
        private const string message = "Profession not found";

        public ProfessionNotFoundException() : base(message) { }
    }
}
