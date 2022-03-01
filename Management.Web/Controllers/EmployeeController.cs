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
    public class EmployeeController : ControllerBase
    {
        private ICustomerRepository _custumerRepository;
        private Mapper mapper;

        public EmployeeController(ICustomerRepository custumerRepository)
        {
            _custumerRepository = custumerRepository;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDTO>();
            });
            mapper = new Mapper(config);
        }

        [HttpGet("{customerId}/orders/{orderId}/employee")]
        public IActionResult GetEmployee(string customerId, int orderId)
        {
            if (!_custumerRepository.CostumerExistes(customerId))
            {
                return NotFound();
            }

            var employee = _custumerRepository.GetEmployerFromOrder(customerId, orderId);

            if (employee == null)
                return NotFound();

            var resultEmployee = mapper.Map<EmployeeDTO>(employee);

            return Ok(resultEmployee);
        }
    }
}
