using Management.Web.Models;

namespace Management.Web.Services
{
    public interface ICategoryInterface
    {
        IEnumerable<Category> GetCategories();
        Category GetCategories(int categotyId);
        IEnumerable<Product> GetProducts(int categoryId);
        Product GetProducts(int categoryId, int productId);
        bool CategoryExiste(int categoryId);
        bool Save();
        void AddProduct(int categoryId, Product product);
        void DeleteOrder(Product product);
    }
}
