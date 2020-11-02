using System;
using System.Collections.Generic;
using MyInventory.API.Models;

namespace MyInventory.API.Services.Settings
{
    public interface IInsertDummyService
    {
        public void Init();
        public List<Client> InsertClients();
    }

    public class InsertDummyService : IInsertDummyService
    {
        private readonly IRepository<Client> _clientsRepo;
        public InsertDummyService(IRepository<Client> clientsRepo)
        {
            _clientsRepo = clientsRepo;
        }

        public void Init()
        {
            _clientsRepo.Create(InsertClients());
        }

        public List<Client> InsertClients()
        {
            return new List<Client>
            {
                new Client
                {
                    Firstname = "John",
                    Lastname = "Talbot",
                    DateOfBirth = new DateTime(1988, 02, 15)
                },
                new Client
                {
                    Firstname = "Albert",
                    Lastname = "McDonald",
                    DateOfBirth = new DateTime(1988, 02, 15)
                },
                new Client
                {
                    Firstname = "Mike",
                    Lastname = "Wooten",
                    DateOfBirth = new DateTime(1988, 02, 15)
                },
            };
        }
    }
}
