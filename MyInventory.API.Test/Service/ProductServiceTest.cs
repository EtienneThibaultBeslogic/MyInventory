using Moq;
using MyInventory.API.Models;
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
    class ProductServiceTest : BaseServiceTest<ProductService>
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
        public void ShouldGetProduct()
        {
            var product = Service.GetProduct(1);

            product.Id.ShouldBe(1);
        }

        [Test]
        public void ShouldGetProducts()
        {
            var products = Service.GetProducts();
            Assert.IsNotEmpty(products);
        }
    }
}
