namespace e_Hospital.Application.Exceptions
{
    public class OrderDetailsNotFoundException : Exception
    {
        private const string _message = "OrderDetails of this User not found";
        public OrderDetailsNotFoundException() : base(_message) { }
    }
}
