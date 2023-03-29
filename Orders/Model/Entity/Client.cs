using System.Text.Json.Serialization;

namespace Orders.Model.Entity
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }

        [JsonIgnore]
        public ICollection<Order>? Orders { get; set; }

        public Client() {
            FirstName = "";
            SecondName = "";
        }
        public Client(int id, string firstName, string secondName)
        {
            Id = id;
            FirstName = firstName;
            SecondName = secondName;
        }

        public override string ToString()
        {
            return $"{Id} - {FirstName} - {SecondName}";
        }

    }
}
