using Microsoft.EntityFrameworkCore;
using Orders.Model;
using Orders.Model.Entity;
namespace Orders.Service.CheckService
{
    public class DbDaoCheck: IDaoCheck
    {
        private readonly ApplicationDbContext db;

        public DbDaoCheck(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<IResult> CheckInfo(int clientId, int orderId)
        {
            var order = await db.Orders.FirstOrDefaultAsync(order => order.Id == orderId && order.ClientId == clientId);
            if (order == null)
            {
                return Results.NotFound();
            }
            var orderProducts = db.OrdersProducts.Where(orderProduct => orderProduct.OrderId == orderId).Include(p => p.Products);
            if (orderProducts == null)
            {
                return Results.NotFound();
            }
            var checkInfo = new Dictionary<string, List<string>>();

            var checkProduct = new List<string>();

            int totalProductCount = 0;

            int productCountById = 0;

            var productTuples = new List<Product>();

            var id_products = new List<int>();

            checkProduct.Add($"{order.Description}");

            checkInfo.Add("description", checkProduct);

            checkProduct.Clear();

            foreach (var product in orderProducts)
            {
                if (!id_products.Contains(product.Id))
                {
                    id_products.Add(product.Id);

                    productCountById = db.OrdersProducts
                        .Where(orderProduct => orderProduct.OrderId == orderId && orderProduct.ProductId == product.Id).Count();
                    var name = await db.Products.FirstOrDefaultAsync(p => p.Id == product.Id);

                    checkProduct.Add($"productName: {name}");

                    checkProduct.Add($"productCount: {productCountById}");

                    checkInfo.Add("product", checkProduct);
                    totalProductCount += productCountById;
                    checkProduct.Clear();
                }
            }
            checkProduct.Add($"{totalProductCount}");
            checkInfo.Add("totalProductCount", checkProduct);
            return Results.Json(checkInfo);
        }


        public async Task<IResult> CheckSumm(int clientId, int orderId)
        {
            var order = await db.Orders.FirstOrDefaultAsync(order => order.Id == orderId && order.ClientId == clientId);
            if (order == null)
            {
                return Results.NotFound();
            }
            var orderProducts = db.OrdersProducts.Where(orderProduct => orderProduct.OrderId == orderId).Include(p => p.Products);
            if (orderProducts == null)
            {
                return Results.NotFound();
            }
            var checkInfo = new Dictionary<string, List<string>>();

            var checkProduct = new List<string>();

            int totalProductPrice = 0;

            int productCountById = 0;

            var productTuples = new List<Product>();

            var id_products = new List<int>();

            checkProduct.Add($"{order.Description}");

            checkInfo.Add("description", checkProduct);

            checkProduct.Clear();

            foreach (var product in orderProducts)
            {
                if (!id_products.Contains(product.Id))
                {
                    id_products.Add(product.Id);

                    var product_item = await db.Products.FirstOrDefaultAsync(p => p.Id == product.Id);
                    productCountById = db.OrdersProducts
                        .Where(orderProduct => orderProduct.OrderId == orderId && orderProduct.ProductId == product.Id).Count();
                    checkProduct.Add($"productName: {product_item.ProductName}");
                    checkProduct.Add($"productPrice: {product_item.Price}");
                    checkInfo.Add("product", checkProduct);
                    totalProductPrice += product_item.Price * productCountById ;
                    checkProduct.Clear();
                }
            }
            checkProduct.Add($"{totalProductPrice}");
            checkInfo.Add("totalProductCount", checkProduct);
            return Results.Json(checkInfo);
        }
    }
}
