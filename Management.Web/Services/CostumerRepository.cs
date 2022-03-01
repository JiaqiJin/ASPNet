using Management.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Management.Web.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        private NorthwindContext _contex;

        public CustomerRepository(NorthwindContext contex)
        {
            _contex = contex;
        }

        public void Add(string costumerId, Order orders)
        {
            var customer = GetCustomers(costumerId, false);
            customer.Orders.Add(orders);
        }

        public bool CostumerExistes(string costumerId)
        {
            return _contex.Customers
                .Any(c => c.CustomerId == costumerId);
        }

        public void DeleteOrder(Order orders)
        {
            _contex.Orders.Remove(orders);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _contex.Customers.OrderBy(c => c.CompanyName).ToList();
        }

        public Customer GetCustomers(string customerId, bool includeOrders)
        {
            if(includeOrders)
            {
                return _contex.Customers
                   .Include(c => c.Orders)
                   .Where(c => c.CustomerId == customerId)
                   .FirstOrDefault();
            }

            return _contex.Customers
               .Where(c => c.CustomerId == customerId)
               .FirstOrDefault();
        }

        public Employee GetEmployerFromOrder(string customerId, int oderId)
        {
            var order = GetOrders(customerId, oderId);
            return order.Employee;
        }

        public IEnumerable<Order> GetOrders(string custumerId)
        {
            return _contex.Orders
                .Where(c => c.CustomerId == custumerId).ToList();
        }

        public Order GetOrders(string customerId, int oderId)
        {
            return _contex.Orders
                .Where(c=> c.CustomerId == customerId
                && c.OrderId == oderId)
                .FirstOrDefault();
        }

        public bool Save()
        {
            return (_contex.SaveChanges() >= 0);
        }
    }
}
