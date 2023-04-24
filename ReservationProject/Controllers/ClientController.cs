using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservationProject.DTO;
using ReservationProject.Entities;
using ReservationProject.Interfaces;

namespace ReservationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService clientService;

        public ClientController(IClientService clientService)
        {
            this.clientService = clientService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetAll()
        {
            return Ok( await clientService.GetClients() );
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ClientDTO>> GetById(int id)
        {
            var Client = await clientService.GetClientById(id);

            if(Client is null)
                return NotFound();

            return Client;

        }

        [HttpPost]
        public async Task<ActionResult<Client>> Post(ClientCreationDTO clientDto)
        {
            var client = await clientService.Add(clientDto);

            if (client is null)
                return BadRequest();

            return client;
        }

        [HttpPut]
        public async Task<ActionResult<Client>> Update(ClientUpdateDTO clientDto)
        {
            var client = await clientService.Update(clientDto);

            if (client is null)
                return BadRequest();

            return client;
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Client>> Delete(int id)
        {
            var client = await clientService.Delete(id);

            if (client is null)
                return BadRequest("Client doesn't exist");

            return Ok(client);
        }
    }
}
