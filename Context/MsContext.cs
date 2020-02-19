using Microservice.Models;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Context
{
    public class MsContext : DbContext
    {
        public MsContext(DbContextOptions<MsContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }

    }
}
