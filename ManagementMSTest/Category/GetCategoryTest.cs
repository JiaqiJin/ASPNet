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

namespace Management.Web.Category
{
    public class GetCategoryTest
    {
        [TestFixture]
        public class GetCategoryQueryTest
        {
            //protected NorthwindContext? _context;
            //protected CategoryImpl? _categoryImpl;
            protected ManagementTestInit _init;
            [SetUp]
            public void SetUp()
            {
                //var fixture = new Fixture();
                ////var orderRecord = fixture.CreateMany<Order>().ToList();
                ////var constrainedText = fixture.Create<string>().Substring(0, 10);
                ////var order = new Mock<Order>();
                //var _category = new Management.Web.Models.Category();
                //_category.CategoryId = 1;
                //_category.CategoryName = "Test";
                //_category.Products = new List<Product>();


                // // DbContext and NorthwindContext
                // var option = new DbContextOptionsBuilder<NorthwindContext>()
                //     .UseInMemoryDatabase(databaseName: $"NorthwindContext")
                //     .Options;

                //_context = new NorthwindContext(option);
                //_context.Categories.AddRange(_category);
                ////_context.Customers.AddRange(customer.Object);
                //_context.SaveChanges();

                //// CustomerRepository
                //_categoryImpl = new CategoryImpl(_context);

                //var mapConfig = new MapperConfiguration(cfg =>
                //{
                //    cfg.AddProfile(new MapperTest());
                //});

                //var mapper = mapConfig.CreateMapper();
                _init = new ManagementTestInit();
            }

            [Test]
            public void GetCategory_InpputOrder_ReturnTrue()
            {
                var localCategory = new Management.Web.Models.Category();
                localCategory.CategoryId = 1;
                localCategory.CategoryName = "Test";
                var categoryImpl = _init._categoryImpl;
                var result = categoryImpl.GetCategories(1);

                Assert.That(result.CategoryName, Is.EqualTo(localCategory.CategoryName));
            }
        }
        }
}
