using Management.Web.Models;

namespace Management.Web.Services
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomers(string customerId, bool includeOrders);
        IEnumerable<Order> GetOrders(string custumerId);
        Order GetOrders(string customerId, int oderId);
        bool CostumerExistes(string costumerId);
        bool Save();
        void Add(string costumerId, Order orders);
        void DeleteOrder(Order orders);
        Employee GetEmployerFromOrder(string customerId, int oderId);
    }
}
