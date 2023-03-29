using Orders.Model.Entity;

namespace Orders.Service.OrderClientServie
{
    public interface IDaoOrderProduct
    {
        Task<List<OrderProduct>> GetAllOrdersProducts();

        Task<OrderProduct> GetOrderProductById(int id);

        Task<OrderProduct> AddOrderProduct(OrderProduct orderProduct);

        Task<OrderProduct> UpdateOrderProduct(OrderProduct orderProduct);

        Task<bool> DeleteOrderProduct(int id);
    }
}
