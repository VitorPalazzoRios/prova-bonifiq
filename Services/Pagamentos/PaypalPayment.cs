namespace ProvaPub.Services.Pagamentos
{
    public class PaypalPayment : IPaymentMethod
    {
        public async Task<bool> ProcessPayment(decimal paymentValue)
        {
            // Lógica de pagamento via PayPal
            if (paymentValue > 0)
            {
                // O pagamento foi bem-sucedido
                return true;
            }
            else
            {
                // O pagamento falhou
                return false;
            }
        }
    }
}
