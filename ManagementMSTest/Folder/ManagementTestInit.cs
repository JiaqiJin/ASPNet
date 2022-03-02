using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Management.Web.Models;
using Management.Web.Services;
using Microsoft.EntityFrameworkCore;

namespace Management.Web.Folder
{
    public class ManagementTestInit
    {
        public NorthwindContext? _context;
        public CategoryImpl? _categoryImpl;
        public CustomerRepository _customerRepository;
        public ManagementTestInit()
        {
            // Category
            var _category = new Management.Web.Models.Category();
            _category.CategoryId = 1;
            _category.CategoryName = "Test";
            _category.Products = new List<Product>();

            // Order
            var order = new Order();
            order.CustomerId = "Juan";
            order.OrderId = 1111;

            // Customer
            var customer = new Customer();
            customer.CustomerId = "Juan";
            customer.CompanyName = "asdasd";
            customer.Orders = new List<Order>();
            customer.Orders.Add(order);

            // DbContext and NorthwindContext
            var option = new DbContextOptionsBuilder<NorthwindContext>()
                .UseInMemoryDatabase(databaseName: $"NorthwindContext")
                .Options;

            _context = new NorthwindContext(option);
            _context.Categories.AddRange(_category);
            _context.Customers.AddRange(customer);
            _context.Orders.AddRange(order);
            _context.SaveChanges();

            // CustomerRepository
            _categoryImpl = new CategoryImpl(_context);
            _customerRepository = new CustomerRepository(_context);

            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperTest());
            });

            var mapper = mapConfig.CreateMapper();
        }
    }
}
