using System;
using System.Collections.Generic;
using MyInventory.API.Models;

namespace MyInventory.API.Services.Settings
{
    public interface IInsertDummyService
    {
        public void Init();
    }

    public class InsertDummyService : IInsertDummyService
    {
        private readonly IRepository<Client> _clientsRepo;
        private readonly IRepository<Product> _productsRepo;
        private readonly IRepository<ShoppingCart> _cartRepo;

        public InsertDummyService(
            IRepository<Client> clientsRepo,
            IRepository<Product> productsRepo,
            IRepository<ShoppingCart> cartRepo
            )
        {
            _clientsRepo = clientsRepo;
            _productsRepo = productsRepo;
            _cartRepo = cartRepo;
        }

        public void Init()
        {
            _clientsRepo.Create(InsertClients());
            _productsRepo.Create(InsertProducts());
            _cartRepo.Create(InsertCarts());
        }

        private static IEnumerable<Client> InsertClients()
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

        private static IEnumerable<Product> InsertProducts()
        {
            return new List<Product>
            {
                new Product { Id = 1, Name = "Macbook Pro", Price = "999.99" },
                new Product { Id = 2, Name = "HP Spectre", Price = "1499.99" },
                new Product { Id = 3, Name = "ThinkPad X1 Carbon", Price = "2999.99" }
            };
        }

        private static IEnumerable<ShoppingCart> InsertCarts()
        {
            return new List<ShoppingCart>
            {
                new ShoppingCart { Id = 1, Client = null, Products = new List<Product>() },
                new ShoppingCart { Id = 2, Client = null, Products = new List<Product>() },
                new ShoppingCart { Id = 3, Client = null, Products = new List<Product>() },
            };
        }
    }
}
