using System.Text.Json.Serialization;

namespace Orders.Model.Entity
{
    public class Product
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public int Article { get; set; }

        public int Price { get; set; }

        public OrderProduct? OrderProduct { get; set; }
        public Product()
        {
            ProductName = "";
            Article = 0;
            Price = 0;
        }

        public override string ToString()
        {
            return $"{Id} - {ProductName} - {Article} - {Price}";
        }
    }
}
