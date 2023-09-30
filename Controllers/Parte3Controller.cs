﻿using Microsoft.AspNetCore.Mvc;
using ProvaPub.Models;
using ProvaPub.Repository;
using ProvaPub.Services;

namespace ProvaPub.Controllers
{
	
	/// <summary>
	/// Esse teste simula um pagamento de uma compra.
	/// O método PayOrder aceita diversas formas de pagamento. Dentro desse método é feita uma estrutura de diversos "if" para cada um deles.
	/// Sabemos, no entanto, que esse formato não é adequado, em especial para futuras inclusões de formas de pagamento.
	/// Como você reestruturaria o método PayOrder para que ele ficasse mais aderente com as boas práticas de arquitetura de sistemas?
	/// </summary>
	[ApiController]
	[Route("[controller]")]
	public class Parte3Controller :  ControllerBase
	{
		[HttpGet("orders")]
		public async Task<Order> PlaceOrder(string paymentMethod, decimal paymentValue, int customerId)
		{
			//Método payorder modificado
			return await new OrderService().PayOrder(paymentMethod, paymentValue, customerId);

            //Explicando o que foi feito, eu criei uma interface IPaymentMethod, que tem um método ProcessPayment
			//Criei classes com os métodos de pagamentos que implementam a interface
			//Modifique a classe OrderService para usar a interface criada e criei dois exception para retornar uma mensagem
        }
    }
}
