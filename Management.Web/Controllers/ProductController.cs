using AutoMapper;
using Management.Web.Data;
using Management.Web.Models;
using Management.Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Management.Web.Controllers
{
    [Route("api/Category")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ICategoryInterface _categoryInterface;
        private Mapper mapper;
        public ProductController(ICategoryInterface categoryInterface)
        {
            _categoryInterface = categoryInterface;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductDTO>();
                //cfg.CreateMap<CustomerDTO, Customer>();
            });
            mapper = new Mapper(config);
        }

        [HttpGet("{categoryId}/product")]
        public IActionResult GetProduct(int categoryId)
        {
            var product = _categoryInterface.GetProducts(categoryId);

            var resultProduct = mapper.Map<IEnumerable<ProductDTO>>(product);

            if(resultProduct == null)
                return NotFound();

            return Ok(resultProduct);
        }
    }
}
