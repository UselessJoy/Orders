using Orders.Model.Entity;
namespace Orders.Service.ClientService
{
    public class PlugDaoClient : IDaoClient
    {
        public static List<Client> clients = new List<Client>();

        public Task<Client> AddClient(Client client)
        {
            client.Id = clients.Count;
            clients.Add(client);
            return Task.Run(() => client);
        }

        public Task<List<Client>> GetAllClients()
        {
            return Task.Run(() => clients);
        }

        public Task<bool> DeleteClient(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Client> UpdateClient(Client client)
        {
            throw new NotImplementedException();
        }

        public Task<Client> GetClientById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
