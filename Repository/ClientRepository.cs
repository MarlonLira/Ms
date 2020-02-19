using Microservice.Context;
using Microservice.Models;
using System.Collections.Generic;
using System.Linq;

namespace Microservice.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly MsContext _context;

        public ClientRepository(MsContext context) => _context = context;

        public void DeleteClient(int Id)
        {
            var rm = GetClientById(Id);
            _context.Clients.Remove(rm);
            Save();
        }

        public Client GetClientById(int Id) => _context.Clients.Find(Id);

        public IEnumerable<Client> GetClients() => _context.Clients.ToList();

        public void InsertClient(Client Client)
        {
            _context.Clients.Add(Client);
            Save();
        }

        public void Save() => _context.SaveChanges();

        public void UpdateClient(Client Client)
        {
            _context.Entry(Client).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }
    }
}
