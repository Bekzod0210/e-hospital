using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Hospital.Application.Exceptions
{
    public class LoginException : Exception
    {
        private const string _message = "Username or Password is wrong";

        public LoginException()
            : base(_message) { }

        public LoginException(Exception innerException)
            : base(_message, innerException) { }
    }
}
