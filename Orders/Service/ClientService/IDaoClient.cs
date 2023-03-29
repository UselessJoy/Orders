using Orders.Model.Entity;

namespace Orders.Service.ClientService
{
    public interface IDaoClient
    {
        Task<List<Client>> GetAllClients();

        Task<Client> GetClientById(int id);

        Task<Client> AddClient(Client client);

        Task<Client> UpdateClient(Client client);

        Task<bool> DeleteClient(int id);
    }
}
