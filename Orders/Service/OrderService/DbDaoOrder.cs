using Orders.Model;
using Microsoft.EntityFrameworkCore;
using Orders.Model.Entity;

namespace Orders.Service.OrderService
{
    public class DbDaoOrder : IDaoOrder
    {
        private readonly ApplicationDbContext db;
        public DbDaoOrder(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<Order> AddOrder(Order order)
        {
            await db.Orders.AddAsync(order);
            await db.SaveChangesAsync();
            return order;
        }

        public async Task<bool> DeleteOrder(int id)
        {
            Order? order = await db.Orders.FirstOrDefaultAsync((order) => order.Id == id);
            if (order != null)
            {
                //Для orderProduct уже используется каскадное удаление при удалении order
                db.Orders.Remove(order);
                await db.SaveChangesAsync();
            }
            return order != null;
        }

        public async Task<List<Order>> GetAllOrders()
        {
            db.Clients.Load();
            return await db.Orders.ToListAsync();
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await db.Orders.FirstOrDefaultAsync((order) => order.Id == id);
        }

        public async Task<Order> UpdateOrder(Order order)
        {
            if (await db.Orders.FirstOrDefaultAsync() != null)
            {
               db.Orders.Update(order);
            }
            return order;
        }
    }
}
