using MyInventory.API.Models;
using MyInventory.API.Models.Dtos;
using MyInventory.API.Services;
using MyInventory.API.Services.Settings;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInventory.API.Test.Service
{
    [TestFixture]
    class ShoppingCartTest : BaseServiceTest<ShoppingCartService>
    {
        private IInsertDummyService _insertDummyService;

        protected override void RegisterServices()
        {
            RegisterService<IInsertDummyService, InsertDummyService>();
        }

        protected override void OnInit()
        {
            _insertDummyService = Get<IInsertDummyService>();
            _insertDummyService.Init();
            base.OnInit();
        }

        [Test]
        public void ShouldCreateShoppingCart()
        {
            var cart = Service.CreateShoppingCart(
                new ClientDto { Id = 0, Firstname = "Antoine", Lastname = "Bernard", DateOfBirth = DateTime.Now.AddYears(-24) });


            cart.Id.ShouldBe(4);
        }

        [Test]
        public void ShouldAddProductToShoppingCart()
        {
            var cart = Service.AddProductToShoppingCart(1, 1);

            Assert.IsNotEmpty(cart.Products.Where(x => x.Id == 1));
        }
    }
}
