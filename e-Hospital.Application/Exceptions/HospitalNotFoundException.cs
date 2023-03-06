using e_Hospital.Domain.Exceptions;

namespace e_Hospital.Application.Exceptions
{
    public class HospitalNotFoundException : EntityNotFoundException
    {
        private const string _message = "Hospital";

        public HospitalNotFoundException() : base(_message) { }
    }
}
