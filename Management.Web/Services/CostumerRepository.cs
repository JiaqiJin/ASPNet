using Management.Web.Models;

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
            throw new NotImplementedException();
        }

        public bool CostumerExistes(string costumerId)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrder(Order orders)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _contex.Customers.OrderBy(c => c.CompanyName).ToList();
        }

        public Customer GetCustomers(string customerId, bool includeOrders)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetOrders(string custumerId)
        {
            throw new NotImplementedException();
        }

        public Order GetOrders(string customerId, int oderId)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }
    }
}
