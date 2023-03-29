using Orders.Model;
using Microsoft.EntityFrameworkCore;
using Orders.Model.Entity;

namespace Orders.Service.ClientService
{
    public class DbDaoClient: IDaoClient
    {
        private readonly ApplicationDbContext db;
        public DbDaoClient(ApplicationDbContext db) 
        {
            this.db = db;
        }

        public async Task<Client> AddClient(Client client)
        {
           await db.Clients.AddAsync(client);
           db.SaveChanges();
           return client;
        }

        public async Task<bool> DeleteClient(int id)
        {
            Client? client = await db.Clients.FirstOrDefaultAsync((client) => client.Id == id);
            if (client != null)
            {
                db.Clients.Remove(client);
                await db.SaveChangesAsync();
            }
            return client != null;
        }

        public async Task<List<Client>> GetAllClients()
        {
            return await db.Clients.ToListAsync();
        }

        public async Task<Client> GetClientById(int id)
        {
            return await db.Clients.FirstOrDefaultAsync((client) => client.Id == id);
        }

        public async Task<Client> UpdateClient(Client client)
        {
            if (await db.Clients.FirstOrDefaultAsync() != null)
            {
                db.Clients.Update(client);
            }
            return client;
        }
    }
}
