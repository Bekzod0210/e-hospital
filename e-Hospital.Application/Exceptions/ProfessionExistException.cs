using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Hospital.Application.Exceptions
{
    public class ProfessionExistException : Exception
    {
        private const string message = "Profession is already exist";

        public ProfessionExistException() : base(message) { }
    }
}
