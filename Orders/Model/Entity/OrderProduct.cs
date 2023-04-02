using Microsoft.AspNetCore.Routing.Constraints;
using System.Text.Json.Serialization;

namespace Orders.Model.Entity
{
    public class OrderProduct
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int ProductCount { get; set; }
        public Product Products { get; set; }

        public int OrderId { get; set; }

        public Order Orders { get; set; }


        public override string ToString()
        {
            return $"{Id} - {ProductId} - {OrderId} - {ProductCount}";
        }
    }
}
