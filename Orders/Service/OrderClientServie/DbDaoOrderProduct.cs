using Orders.Model;
using Microsoft.EntityFrameworkCore;
using Orders.Model.Entity;

namespace Orders.Service.OrderClientServie
{
    public class DbDaoOrderProduct : IDaoOrderProduct
    {
        private readonly ApplicationDbContext db;
        public DbDaoOrderProduct(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<OrderProduct> AddOrderProduct(OrderProduct orderProduct)
        {
            await db.OrdersProducts.AddAsync(orderProduct);
            db.SaveChanges();
            return orderProduct;
        }

        public async Task<bool> DeleteOrderProduct(int id)
        {
            OrderProduct? orderProduct = await db.OrdersProducts.FirstOrDefaultAsync((orderProduct) => orderProduct.Id == id);
            if (orderProduct != null)
            {
                db.OrdersProducts.Remove(orderProduct);
                await db.SaveChangesAsync();
            }
            return orderProduct != null;
        }

        public async Task<List<OrderProduct>> GetAllOrdersProducts()
        {
            return await db.OrdersProducts.ToListAsync();
        }

        public async Task<OrderProduct> GetOrderProductById(int id)
        {
            return await db.OrdersProducts.FirstOrDefaultAsync((orderProduct) => orderProduct.Id == id);
        }

        public async Task<OrderProduct> UpdateOrderProduct(OrderProduct orderProduct)
        {
            if (await db.OrdersProducts.FirstOrDefaultAsync() != null)
            {
                db.OrdersProducts.Update(orderProduct);
            }
            return orderProduct;
        }
    }
}
