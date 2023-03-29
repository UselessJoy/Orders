using Orders.Model.Entity;
using Orders.Service.ProductService;

namespace Orders.Service.OrderService
{
    public class PlugDaoOrder : IDaoOrder
    {
        public static List<Order> orders = new List<Order>();

        public Task<Order> AddOrder(Order order)
        {
            order.Id = orders.Count;
            orders.Add(order);
            return Task.Run(() => order);
        }

        public Task<List<Order>> GetAllOrders()
        {
            return Task.Run(() => orders);
        }

        public Task<bool> DeleteOrder(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Order> UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrderById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
