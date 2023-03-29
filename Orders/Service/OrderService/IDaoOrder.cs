using Orders.Model.Entity;

namespace Orders.Service.OrderService
{
    public interface IDaoOrder
    {
        Task<List<Order>> GetAllOrders();

        Task<Order> GetOrderById(int id);

        Task<Order> AddOrder(Order order);

        Task<Order> UpdateOrder(Order order);

        Task<bool> DeleteOrder(int id);
    }
}
