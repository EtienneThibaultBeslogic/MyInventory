using System.Linq;
using MyInventory.API.Models;
using MyInventory.API.Services;
using MyInventory.API.Services.Settings;
using NUnit.Framework;

namespace MyInventory.API.Test.Service
{
    [TestFixture]
    class ProductServiceTest : BaseServiceTest<ProductService>
    {
        private IRepository<Product> _productRepo;
        private IInsertDummyService _insertDummyService;

        protected override void RegisterServices()
        {
            RegisterService<IInsertDummyService, InsertDummyService>();
        }

        protected override void OnInit()
        {
            _productRepo = Get<IRepository<Product>>();
            _insertDummyService = Get<IInsertDummyService>();
            _insertDummyService.Init();
            base.OnInit();
        }

        [Test]
        public void ShouldGetProduct()
        {
            //Arrange
            const int id = 1;
            var expectedProduct = _productRepo.SingleOrDefault(c => c.Id == id);

            //Act
            var product = Service.GetProduct(id);

            //Assert
            expectedProduct.ShouldNotBe(null);
            expectedProduct.Id.ShouldBe(product.Id);
            expectedProduct.Name.ShouldBe(product.Name);
            expectedProduct.Price.ShouldBe(product.Price);
        }

        [Test]
        public void ShouldGetProducts()
        {
            //Arrange
            const int numberOfProduct = 3;

            //Act
            var products = Service.GetProducts();

            //Assert
            products.Count().ShouldBe(numberOfProduct);
        }
    }
}
