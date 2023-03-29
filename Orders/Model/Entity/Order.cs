using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Orders.Model.Entity
{
    public class Order
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int ClientId { get; set; }

        public Client? Client { get; set; }

        public OrderProduct? OrderProduct { get; set; }

        public Order()
        {
            Description = "";
        }

        public override string ToString()
        {
            return $"{Id} - {Description} - {ClientId}";
        }
    }
}
