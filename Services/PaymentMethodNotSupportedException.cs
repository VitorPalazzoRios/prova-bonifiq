namespace ProvaPub.Services
{
    public class PaymentMethodNotSupportedException : Exception
    {
        public PaymentMethodNotSupportedException() { }

        public PaymentMethodNotSupportedException(string message) : base(message) { }

        public PaymentMethodNotSupportedException(string message, Exception innerException) : base(message, innerException) { }
    }
}
