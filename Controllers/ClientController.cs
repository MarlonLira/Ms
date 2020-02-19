using Microservice.Models;
using Microservice.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;
        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        // GET: api/Client
        [HttpGet]
        public IActionResult Get()
        {
            var Clients = _clientRepository.GetClients();
            return new OkObjectResult(Clients);
        }

        // GET: api/Client/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var Client = _clientRepository.GetClientById(id);
            return new OkObjectResult(Client);
        }

        // POST: api/Client
        [HttpPost]
        public IActionResult Post([FromBody] Client value)
        {
            using (var scope = new TransactionScope())
            {
                _clientRepository.InsertClient(value);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = value.Id }, value);
            }
        }

        // PUT: api/Client/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Client value)
        {
            using (var scope = new TransactionScope())
            {
                _clientRepository.UpdateClient(value);
                scope.Complete();
                return new OkResult();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using (var scope = new TransactionScope())
            {
                _clientRepository.DeleteClient(id);
                scope.Complete();
                return new OkResult();
            }
        }
    }
}
