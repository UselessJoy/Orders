using Orders.Model;
using Orders.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace Orders.Service.ProductService
{
    public class DbDaoProduct : IDaoProduct
    {
        private readonly ApplicationDbContext db;
        public DbDaoProduct(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<Product> AddProduct(Product product)
        {
            await db.Products.AddAsync(product);
            db.SaveChanges();
            return product;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            Product? product = await db.Products.FirstOrDefaultAsync((product) => product.Id == id);
            if (product != null)
            {
                db.Products.Remove(product);
                await db.SaveChangesAsync();
            }
            return product != null;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await db.Products.ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await db.Products.FirstOrDefaultAsync((product) => product.Id == id);
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            if (await db.Products.FirstOrDefaultAsync() != null)
            {
                db.Products.Update(product);
            }
            return product;
        }
    }
}
