using ProvaPub.Models;
using ProvaPub.Services.Pagamentos;

namespace ProvaPub.Services
{
	public class OrderService
	{
		//Modificando para usar a interface que foi criada
        private readonly Dictionary<string, IPaymentMethod> paymentMethods;
		//Instanciando os metodos de pagamento
        public OrderService()
        {
            paymentMethods = new Dictionary<string, IPaymentMethod>
        {
            { "pix", new PixPayment() },
            { "creditcard", new CreditCardPayment() },
            { "paypal", new PaypalPayment() }
        };
        }

        //Mudando para receber o método de pagamento
        public async Task<Order> PayOrder(string paymentMethod, decimal paymentValue, int customerId)
        {
            if (paymentMethods.TryGetValue(paymentMethod, out var paymentProcessor))
            {
                var paymentResult = await paymentProcessor.ProcessPayment(paymentValue);

                if (paymentResult)
                {
                    return await Task.FromResult(new Order()
                    {
                        Value = paymentValue
                    });
                }
                else
                {
                    // Lidar com falha no pagamento, se necessário, a classe de exception foi criada no services
                    throw new PaymentFailedException("O pagamento falhou.");
                }
            }
            else
            {
                // Lidar com método de pagamento desconhecido, se necessário
                throw new PaymentMethodNotSupportedException("Método de pagamento não suportado.");
            }
        }


    }
}
