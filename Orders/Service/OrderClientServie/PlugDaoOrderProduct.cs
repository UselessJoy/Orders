using Orders.Model.Entity;

namespace Orders.Service.OrderClientServie
{
    public class PlugDaoOrderProduct : IDaoOrderProduct
    {
        public static List<OrderProduct> ordersProducts = new List<OrderProduct>();

        public Task<OrderProduct> AddOrderProduct(OrderProduct orderProduct)
        {
            orderProduct.Id = ordersProducts.Count;
            ordersProducts.Add(orderProduct);
            return Task.Run(() => orderProduct);
        }

        public Task<List<OrderProduct>> GetAllOrdersProducts()
        {
            return Task.Run(() => ordersProducts);
        }

        public Task<bool> DeleteOrderProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OrderProduct> UpdateOrderProduct(OrderProduct orderProduct)
        {
            throw new NotImplementedException();
        }

        public Task<OrderProduct> GetOrderProductById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
