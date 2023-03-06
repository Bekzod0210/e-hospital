using e_Hospital.Domain.Entities;

namespace e_Hospital.Application.Exceptions
{
    public class MedicineNotFoundException : Exception
    {
        private const string _message = $"{nameof(Medicine)} not found";
        public MedicineNotFoundException() : base(_message) { }
    }
}
