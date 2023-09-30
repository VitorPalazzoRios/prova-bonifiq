namespace ProvaPub.Services.Pagamentos
{
    public class CreditCardPayment : IPaymentMethod
    {
        public async Task<bool> ProcessPayment(decimal paymentValue)
        {
            // Lógica de pagamento via cartão de crédito
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
