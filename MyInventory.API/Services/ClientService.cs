using System.Collections.Generic;
using MyInventory.API.Models;
using MyInventory.API.Models.Dtos;
using MyInventory.API.Services.Settings;
using System.Linq;

namespace MyInventory.API.Services
{
    public interface IClientService
    {
        public ClientDto GetClient(int id);
        public IEnumerable<ClientDto> GetClients();
        public ClientDto CreateClient(ClientDto clientDto);
        public ClientDto UpdateClient(ClientDto clientDto);
        public void DeleteClient(int id);
    }

    public class ClientService: IClientService
    {
        private readonly IRepository<Client> _clientsRepo;
        public ClientService(IRepository<Client> clientsRepo)
        {
            _clientsRepo = clientsRepo;
        }

        public ClientDto GetClient(int id)
        {
            var client = _clientsRepo.SingleOrDefault(c => c.Id == id);
            return client == null ? null : ClientDto.ToDto(client);
        }

        public IEnumerable<ClientDto> GetClients()
        {
            return _clientsRepo.Select(ClientDto.ToDto);
        }

        public ClientDto CreateClient(ClientDto clientDto)
        {
            var client = _clientsRepo.Create(new Client
            {
                Firstname = clientDto.Lastname,
                Lastname = clientDto.Lastname,
                DateOfBirth = clientDto.DateOfBirth,
            });

            return ClientDto.ToDto(client);
        }

        public ClientDto UpdateClient(ClientDto clientDto)
        {
            var client = _clientsRepo.SingleOrDefault(c => c.Id == clientDto.Id);

            if (client == null) return null;

            client.Firstname = clientDto.Firstname;
            client.Lastname = clientDto.Lastname;
            client.DateOfBirth = clientDto.DateOfBirth;

            return ClientDto.ToDto(_clientsRepo.Update(client));
        }

        public void DeleteClient(int id)
        {
            _clientsRepo.DeleteById(id);
        }
    }
}
