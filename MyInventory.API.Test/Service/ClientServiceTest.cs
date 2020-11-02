using MyInventory.API.Models.Dtos;
using MyInventory.API.Services;
using MyInventory.API.Services.Settings;
using MyInventory.API.Test;
using NUnit.Framework;
using System.Linq;

namespace MyInventory.API.Controllers
{
    [TestFixture]
    public class ClientServiceTest : BaseServiceTest<ClientService>
    {
        private IInsertDummyService _insertDummyService;
        public ClientServiceTest()
        {
        }
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
        public void ShouldReturnClients()
        {
            //Arrange
            var clients = _insertDummyService.InsertClients().Select(ClientDto.ToDto);

            //Act
            var result = Service.GetClients();

            //Assert
            CollectionAssert.AreEquivalent(result, clients);
        }
    }
}
