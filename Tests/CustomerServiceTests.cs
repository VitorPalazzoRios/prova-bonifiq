using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProvaPub.Services;
using Microsoft.AspNetCore.Routing;
using ProvaPub.Models;
using ProvaPub.Repository;

namespace ProvaPub.Tests

{
    [TestFixture]
    public class CustomerServiceTests
    {
        [Test]
        public async Task CanPurchase_CustomerDoesNotExist_ReturnsFalse()
        {
            // Arrange
            var customerId = 213213; 
            var purchaseValue = 100; 
            var mockDbContext = new Mock<TestDbContext>();
            var service = new CustomerService(mockDbContext.Object);

            // Act
            var result = await service.CanPurchase(customerId, purchaseValue);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task CanPurchase_CustomerAlreadyPurchasedThisMonth_ReturnsFalse()
        {
            // Arrange
            var customerId = 1;
            var purchaseValue = 100; 
            var mockDbContext = new Mock<TestDbContext>();
            var service = new CustomerService(mockDbContext.Object);

            // Mock the DbSet and its behavior
            var mockCustomers = new Mock<DbSet<Customer>>();
            mockCustomers.Setup(c => c.FindAsync(customerId)).ReturnsAsync(new Customer());

            var mockOrders = new Mock<DbSet<Order>>();
            mockDbContext.Setup(c => c.Customers).Returns(mockCustomers.Object);
            mockDbContext.Setup(c => c.Orders).Returns(mockOrders.Object);

            // Mock the Orders data to simulate a purchase this month
            var baseDate = DateTime.UtcNow.AddMonths(-1);
            var ordersThisMonth = new List<Order>
            {
                new Order { CustomerId = customerId, OrderDate = DateTime.UtcNow }
            }.AsQueryable();

            mockOrders.As<IQueryable<Order>>().Setup(o => o.Provider).Returns(ordersThisMonth.Provider);
            mockOrders.As<IQueryable<Order>>().Setup(o => o.Expression).Returns(ordersThisMonth.Expression);
            mockOrders.As<IQueryable<Order>>().Setup(o => o.ElementType).Returns(ordersThisMonth.ElementType);
            mockOrders.As<IQueryable<Order>>().Setup(o => o.GetEnumerator()).Returns(ordersThisMonth.GetEnumerator());

            // Act
            var result = await service.CanPurchase(customerId, purchaseValue);

            // Assert
            Assert.IsFalse(result);
        }
    }
}