using Management.Web.Models;

namespace Management.Web.Services
{
    public class CategoryImpl : ICategoryInterface
    {
        private NorthwindContext _contex;

        public CategoryImpl(NorthwindContext contex)
        {
            _contex = contex;
        }

        public void Add(string categoryId, Product product)
        {
            throw new NotImplementedException();
        }

        public bool CategoryExiste(string categoryId)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrder(Product product)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetCategories()
        {
            return _contex.Categories.OrderBy(c => c.CategoryName).ToList();
        }

        public Category GetCategories(string categotyId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProducts(string categoryId)
        {
            throw new NotImplementedException();
        }

        public Order GetProducts(string categoryId, int productId)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }
    }
}
