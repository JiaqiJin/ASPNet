using AutoMapper;
using Management.Web.Data;
using Management.Web.Models;
using Management.Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// https://localhost:44343/api/Customer/ALFKI/orders
namespace Management.Web.Controllers
{
    [Route("api/Customer")]
    [ApiController]
    public class OrderController : Controller
    {
        private ICustomerRepository _custumerRepository;
        private Mapper mapper;

        public OrderController(ICustomerRepository custumerRepository)
        {
            _custumerRepository = custumerRepository;
            var config = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<Order, OrderDTO>();
                cfg.CreateMap<OrderCreateDTO, Order>();
                cfg.CreateMap<OrdersForUpdateDTO, Order>();
                cfg.CreateMap<OrdersForUpdateDTO, OrderCreateDTO>();
            });

            mapper = new Mapper(config);
        }

        [HttpGet("{customerId}/orders")]
        public IActionResult GetOrders(string customerId)
        {
            if(!_custumerRepository.CostumerExistes(customerId))
            {
                return NotFound();
            }

            var orders = _custumerRepository.GetOrders(customerId);

            if (orders == null)
            {
                return NotFound();
            }

            var resultOrder = mapper.Map<IEnumerable<OrderDTO>>(orders);

            return Ok(resultOrder);
        }

        [HttpGet("{customerId}/orders/{orderId}", Name = "GetOrder")]
        public IActionResult GetOrders(string customerId, int orderId)
        {
            if(!_custumerRepository.CostumerExistes(customerId))
            {
                return NotFound();
            }

            var order = _custumerRepository.GetOrders(customerId, orderId);

            if (order == null)
            {
                return NotFound();
            }

            var resultOrder = mapper.Map<OrderDTO>(order);

            return Ok(resultOrder);
        }

        [HttpPost("{customerId}/orders")]
        public IActionResult CreateOrder(string customerId, [FromBody]OrderCreateDTO order)
        {
            if (order == null)
                return BadRequest();

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!_custumerRepository.CostumerExistes(customerId))
            {
                return NotFound();
            }

            var finalOder = mapper.Map<Order>(order);
            _custumerRepository.Add(customerId, finalOder);

            if(!_custumerRepository.Save())
            {
                return StatusCode(500,
                   "Please verify your data");
            }

            var customerOrderCreate = mapper.Map<OrderDTO>(finalOder);

            return CreatedAtRoute("GetOrder",
                new
                {
                    // "{customerId}/orders/{orderId}"
                    customerId = customerId,
                    orderId = customerOrderCreate.CustomerId
                }, customerOrderCreate);
        }

        [HttpPut("{customerId}/orders/{id}")]
        public IActionResult UpdateOrder(string customerId, int id,
        [FromBody] OrdersForUpdateDTO order)
        {
            if (order == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_custumerRepository.CostumerExistes(customerId))
            {
                return NotFound();
            }

            var existingOrder = _custumerRepository
                .GetOrders(customerId, id);
            if (existingOrder == null)
            {
                return NotFound();
            }

            mapper.Map(order, existingOrder);

            if (!_custumerRepository.Save())
            {
                return StatusCode(500,
                    "Please verify your data");
            }
           
            return NoContent();
        }

        [HttpDelete("{customerID}/orders/{id}")]
        public IActionResult DeleteOrder(string customerID, int id)
        {
            if (!_custumerRepository.CostumerExistes(customerID))
            {
                return NotFound();
            }

            var existingOrder = _custumerRepository.GetOrders(customerID, id);
            if (existingOrder == null)
            {
                return NotFound();
            }

            _custumerRepository.DeleteOrder(existingOrder);
            if (!_custumerRepository.Save())
            {
                return StatusCode(500, "Please verify your data");
            }
            return NoContent();
        }
    }
}
