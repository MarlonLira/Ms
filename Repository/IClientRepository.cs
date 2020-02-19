using Microservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice.Repository
{
    public interface IClientRepository
    {
        IEnumerable<Client> GetClients();
        Client GetClientById(int Id);
        void InsertClient(Client Client);
        void UpdateClient(Client Client);
        void DeleteClient(int Id);
        void Save();
    }
}
