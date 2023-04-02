using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Orders.Model;
using Orders.Model.Entity;
using System.IO.Pipes;

namespace Orders.Service.CheckService
{
    public class DbDaoCheck: IDaoCheck
    {
        private readonly ApplicationDbContext db;

        public DbDaoCheck(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<IResult> CheckInfo(int orderId)
        {

            var products = db.OrdersProducts.Where(op => op.OrderId == orderId).Select(op => new Checks(op.Products, op.ProductCount)).ToList();
            var totalCount = products.Select(p => p.Count).Sum();
            return Results.Json(new { products, totalCount });
        }

        public async Task<IResult> CheckSumm(int orderId)
        {
            var products = db.OrdersProducts.Where(op => op.OrderId == orderId).Select(op => new Checks(op.Products, op.ProductCount)).ToList();
            var totalPrice = products.Select(p => p.PriceCount).Sum();
            return Results.Json(new { products, totalPrice });
        }
    }
}
