using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RegistryCode { get; set; }
        public DateTime UpdatedAt { get; set; }
        
    }
}
