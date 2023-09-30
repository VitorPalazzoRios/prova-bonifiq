﻿using Microsoft.AspNetCore.Mvc;
using ProvaPub.Models;
using ProvaPub.Repository;
using ProvaPub.Services;

namespace ProvaPub.Controllers
{
	
	[ApiController]
	[Route("[controller]")]
	public class Parte2Controller :  ControllerBase
	{
		/// <summary>
		/// Precisamos fazer algumas alterações:
		/// 1 - Não importa qual page é informada, sempre são retornados os mesmos resultados. Faça a correção.
		/// 2 - Altere os códigos abaixo para evitar o uso de "new", como em "new ProductService()". Utilize a Injeção de Dependência para resolver esse problema
		/// 3 - Dê uma olhada nos arquivos /Models/CustomerList e /Models/ProductList. Veja que há uma estrutura que se repete. 
		/// Como você faria pra criar uma estrutura melhor, com menos repetição de código? E quanto ao CustomerService/ProductService. Você acha que seria possível evitar a repetição de código?
		/// 
		/// </summary>
		TestDbContext _ctx;
        private readonly ProductService _productService;
        private readonly CustomerService _customerService;


        //Recebendo os servicos como parametro para remover as instâncias dos serviços com new 
        public Parte2Controller(TestDbContext ctx , ProductService productService, CustomerService customerService)
		{
			_ctx = ctx;

            _productService = productService;
            _customerService = customerService;
        }



        //fiz uma forma atraves da injecao de dependencia para remover o uso do new 
        //Para evitar a repetição de código eu fiz uma classe com as propiedades semelhantes a do Customer e Product, e depois herdei em ambas
        //Não consegui testar totalmente pelo fato de ele me dar um erro que não tenho acesso liberado ao SQL Banco de dados...
        [HttpGet("products")]
        public ProductList ListProducts(int page)
        {
            return _productService.ListProducts(page);
        }

        [HttpGet("customers")]
        public CustomerList ListCustomers(int page)
        {
            return _customerService.ListCustomers(page);
        }

    }
}
