using AutoMapper;
using Management.Web.Data;
using Management.Web.Models;
using Management.Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Management.Web.Controllers
{
    [Route("api/Customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerRepository _custumerRepository;
        private AutoMapper.Mapper mapper;
        public CustomerController(ICustomerRepository custumerRepository)
        {
            _custumerRepository = custumerRepository;
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Customer, CustomerDTO>();
                //cfg.CreateMap<CustomerDTO, Customer>();
            });
            mapper = new Mapper(config);
        }

        [HttpGet()]
        public IActionResult GetCustomers()
        {
            var customers = _custumerRepository.GetCustomers();

            var resultCustomes = mapper.Map<IEnumerable<CustomerDTO>>(customers);

            return Ok(resultCustomes);

        }

        [HttpGet("{id}")]
        public IActionResult GetCustomer(string id)
        {
            var customer = _custumerRepository.GetCustomers(id, false);

            var resultCustomer = mapper.Map<CustomerDTO>(customer);

            return Ok(resultCustomer);
        }
    }
}
