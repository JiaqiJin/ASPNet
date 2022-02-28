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
    public class CategoryController : Controller
    {
        private ICategoryInterface _categoryInterface;
        private Mapper mapper;
        public CategoryController(ICategoryInterface categoryInterface)
        {
            _categoryInterface = categoryInterface;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Category, CategoryDTO>();
                //cfg.CreateMap<CustomerDTO, Customer>();
            });
            mapper = new Mapper(config);
        }

        [HttpGet()]
        public IActionResult GetCategory()
        {
            var categories = _categoryInterface.GetCategories();

            var resultCategories = mapper.Map<IEnumerable<CategoryDTO>>(categories);

            return Ok(resultCategories);

        }
    }
}
