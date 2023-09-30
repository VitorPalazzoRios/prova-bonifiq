namespace ProvaPub.Services
{
    public interface IPaymentMethod
    {
        Task<bool> ProcessPayment(decimal paymentValue);
    }
}
