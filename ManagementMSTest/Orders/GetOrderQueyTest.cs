using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using AutoMapper;
using Management.Web.Folder;
using Management.Web.Models;
using Management.Web.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;

namespace Management.Web.Orders
{
    public class GetOrderQueyNUnitTest
    {
        [TestFixture]
        public class GetOrderQueryTest
        {
            protected NorthwindContext? _context;
            protected CustomerRepository? _customerRepository;
            [SetUp]
            public void SetUp()
            {
                var fixture = new Fixture();
                //var orderRecord = fixture.CreateMany<Order>().ToList();
                //var constrainedText = fixture.Create<string>().Substring(0, 10);
                var order = new Mock<Order>();
                order.Object.CustomerId = "Juan";
                order.Object.OrderId = 1111;

                var customer = new Mock<Customer>();
                customer.Object.CustomerId = "Juan";
                customer.Object.CompanyName = "asdasd";
                var objet = order.Object;
               // customer.Object.Orders.Add(order.Object);

               // Order
               //orderRecord.Add(fixture.Build<Order>()
               //    .With(tr => tr.CustomerId, string.Empty)
               //    .With(tr => tr.OrderId, int.MinValue)
               //    .Create());

               // DbContext and NorthwindContext
               var option = new DbContextOptionsBuilder<NorthwindContext>()
                    .UseInMemoryDatabase(databaseName: $"NorthwindContext")
                    .Options;

                _context = new NorthwindContext(option);
                _context.Orders.AddRange(order.Object);
                _context.Customers.AddRange(customer.Object);
                _context.SaveChanges();

                // CustomerRepository
                _customerRepository = new CustomerRepository(_context);

                var mapConfig = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new MapperTest());
                });

                var mapper = mapConfig.CreateMapper();
            }

            //[Test]
            //public void GetOrders_InputOrder_ReturnTrue()
            //{
            //    Order localOrder = new Order();
            //    localOrder.CustomerId = "Juan";
            //    localOrder.OrderId = 1111;
            //    var rep = _customerRepository;
            //    //_customerRepository.Add("juan", localOrder);
            //    var result = _customerRepository.GetOrders("Juan", 1111);

            //    Assert.That(result.CustomerId, Is.EqualTo("Juan"));
            //}
        }
    }
}
