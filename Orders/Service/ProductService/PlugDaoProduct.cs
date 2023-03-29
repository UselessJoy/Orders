using Orders.Model.Entity;

namespace Orders.Service.ProductService
{
    public class PlugDaoProduct : IDaoProduct
    {
        public static List<Product> products = new List<Product>();

        public Task<Product> AddProduct(Product product)
        {
            product.Id = products.Count;
            products.Add(product);
            return Task.Run(() => product);
        }

        public Task<List<Product>> GetAllProducts()
        {
            return Task.Run(() => products);
        }

        public Task<bool> DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
