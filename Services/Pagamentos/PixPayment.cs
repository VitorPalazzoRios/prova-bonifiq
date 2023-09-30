namespace ProvaPub.Services.Pagamentos
{
    public class PixPayment : IPaymentMethod
    {
        public async Task<bool> ProcessPayment(decimal paymentValue)
        {
            // Lógica de pagamento via Pix
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
