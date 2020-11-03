using Microsoft.AspNetCore.Mvc;
using MyInventory.API.Models.Dtos;
using MyInventory.API.Services;
using MyInventory.API.Services.Settings;

namespace MyInventory.API.Controllers
{
    public class ClientController : ApiControllerBase
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet("{id}")]
        public IActionResult GetClient(int id)
        {
            return Json(_clientService.GetClient(id));
        }

        [HttpGet]
        public IActionResult GetClients()
        {
            return Json(_clientService.GetClients());
        }

        [HttpPut]
        public IActionResult CreateClient(ClientDto clientDto)
        {
            return Json(_clientService.CreateClient(clientDto));
        }

        [HttpPost]
        public IActionResult GetClient(ClientDto clientDto)
        {
            return Json(_clientService.UpdateClient(clientDto));
        }

        [HttpDelete]
        public IActionResult DeleteClient(int id)
        {
            _clientService.DeleteClient(id);
            return Ok();
        }
    }
}
