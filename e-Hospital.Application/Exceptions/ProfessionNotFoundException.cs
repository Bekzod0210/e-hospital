using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Hospital.Application.Exceptions
{
    public class ProfessionNotFoundException : Exception
    {
        private const string message = "Profession not found";

        public ProfessionNotFoundException() : base(message) { }
    }
}
