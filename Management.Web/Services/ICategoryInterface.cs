using Management.Web.Models;

namespace Management.Web.Services
{
    public interface ICategoryInterface
    {
        IEnumerable<Category> GetCategories();
        Category GetCategories(string categotyId);
        IEnumerable<Product> GetProducts(string categoryId);
        Order GetProducts(string categoryId, int productId);
        bool CategoryExiste(string categoryId);
        bool Save();
        void Add(string categoryId, Product product);
        void DeleteOrder(Product product);
    }
}
