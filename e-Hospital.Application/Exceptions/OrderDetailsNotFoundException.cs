using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Hospital.Application.Exceptions
{
    public class OrderDetailsNotFoundException : Exception
    {
        private const string _message = "OrderDetails of this User not found";
        public OrderDetailsNotFoundException() : base(_message) { }
    }
}
