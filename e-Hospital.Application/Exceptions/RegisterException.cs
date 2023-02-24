using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Hospital.Application.Exceptions
{
    public class RegisterException : Exception
    {
        private const string _message = "Registration error!";

        public RegisterException()
            : base(_message) { }

        public RegisterException(Exception innerException)
            : base(_message, innerException) { }
    }
}
