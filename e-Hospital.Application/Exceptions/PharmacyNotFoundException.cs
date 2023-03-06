using e_Hospital.Domain.Exceptions;

namespace e_Hospital.Application.Exceptions
{
    public class PharmacyNotFoundExeption : EntityNotFoundException
    {
        private const string _message = "Pharmacy";

        public PharmacyNotFoundExeption() : base(_message) { }
    }
}
