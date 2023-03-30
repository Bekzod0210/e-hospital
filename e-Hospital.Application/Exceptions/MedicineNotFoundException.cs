using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using e_Hospital.Domain.Entities;

namespace e_Hospital.Application.Exceptions
{
    public class MedicineNotFoundException : Exception
    {
        private const string _message = $"{nameof(Medicine)} not found";
        public MedicineNotFoundException() : base(_message) { }
    }
}
