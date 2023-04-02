using System.Xml.Schema;
using Orders.Model.Entity;
namespace Orders.Service.CheckService
{

    public class Checks
    {
        public Product Product { get; set; }

        public int Count { get; set; }

        public int PriceCount { get; set; }

        public Checks() 
        {
            Product = new Product();
            Count = 0;
            PriceCount = 0;
        }
        public Checks(Product product, int count)
        {
            Product = product;
            Count = count;
            PriceCount = product.Price * count;
        }
    }
}
