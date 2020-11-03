using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MyInventory.API.Models.Dtos;
using MyInventory.API.Services;

namespace MyInventory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet("{id}")]
        public ClientDto GetClient(int id)
        {
            return _clientService.GetClient(id);
        }

        [HttpGet]
        public IEnumerable<ClientDto> GetClients()
        {
            return _clientService.GetClients();
        }

        [HttpPut]
        public ClientDto CreateClient(ClientDto clientDto)
        {
            return _clientService.CreateClient(clientDto);
        }

        [HttpPost]
        public ClientDto GetClient(ClientDto clientDto)
        {
            return _clientService.UpdateClient(clientDto);
        }

        [HttpDelete]
        public IActionResult DeleteClient(int id)
        {
            _clientService.DeleteClient(id);
            return Ok();
        }
    }
}
