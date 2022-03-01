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

        public void AddProduct(int categoryId, Product product)
        {
            var category = GetCategories(categoryId);
            category.Products.Add(product);
        }

        public bool CategoryExiste(int categoryId)
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

        public Category GetCategories(int categotyId)
        {
            return _contex.Categories
                .Where(c => c.CategoryId == categotyId)
                .FirstOrDefault();
        }

        public IEnumerable<Product> GetProducts(int categoryId)
        {
            return _contex.Products
                .Where(c => c.CategoryId == categoryId).ToList();
        }

        public Product GetProducts(int categoryId, int productId)
        {
            return _contex.Products
                .Where(c => c.CategoryId == categoryId
                && c.ProductId == productId)
                .FirstOrDefault();
        }

        public bool Save()
        {
            return (_contex.SaveChanges() >= 0);
        }
    }
}
