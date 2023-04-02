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
            //Создать list из продуктов и их количества
            var products = db.OrdersProducts.Where(op => op.OrderId == orderId).Select(op => new Checks(op.Products, op.ProductCount)).ToList();
            //Вычислить totalCount, путем суммирования количества каждого из продуктов в заказе
            var totalCount = products.Select(p => p.Count).Sum();
            //Отправить List из продуктов и их количества и общее количество
            return Results.Json(new { products, totalCount });
        }

        public async Task<IResult> CheckSumm(int orderId)
        {
            //Создать list из продуктов и их количества
            var products = db.OrdersProducts.Where(op => op.OrderId == orderId).Select(op => new Checks(op.Products, op.ProductCount)).ToList();
            //Вычислить totalPrice, путем суммирования общей цены за каждый продукт
            var totalPrice = products.Select(p => p.PriceCount).Sum();
            //Отправить List из продуктов и их количества и общую сумму
            return Results.Json(new { products, totalPrice });
        }
    }
}
