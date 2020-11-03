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
        private readonly IRepository<Product> _productsRepo;
        private readonly IRepository<Order> _orderRepo;
        private readonly IRepository<ShoppingCart> _cartRepo;
        public InsertDummyService(
            IRepository<Client> clientsRepo,
            IRepository<Product> productsRepo,
            IRepository<Order> orderRepo,
            IRepository<ShoppingCart> cartRepo
            )
        {
            _clientsRepo = clientsRepo;
            _productsRepo = productsRepo;
            _orderRepo = orderRepo;
            _cartRepo = cartRepo;
        }

        public void Init()
        {
            _clientsRepo.Create(InsertClients());
            _productsRepo.Create(InsertProducts());
            _orderRepo.Create(InsertOrders());
            _cartRepo.Create(InsertCarts());
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

        public List<Product> InsertProducts()
        {
            return new List<Product>
            {
                new Product { Id = 1, Name = "Toilette", Price = "79.99" },
                new Product { Id = 2, Name = "ASP.Net Unleashed", Price = "59.99" },
                new Product { Id = 3, Name = "Silverlight Unleashed", Price = "29.99" }
            };
        }

        public List<Order> InsertOrders()
        {
            return new List<Order>
            {
                new Order { Id = 1, Price = 9.99, Discount = 0.99, Status = Enum.OrderStatus.Ordered, Client = null },
                new Order { Id = 2, Price = 9.99, Discount = 0.99, Status = Enum.OrderStatus.Ordered, Client = null },
                new Order { Id = 3, Price = 9.99, Discount = 0.99, Status = Enum.OrderStatus.Ordered, Client = null },
            };
        }

        public List<ShoppingCart> InsertCarts()
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
