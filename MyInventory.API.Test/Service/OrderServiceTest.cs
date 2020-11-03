using MyInventory.API.Services;
using MyInventory.API.Services.Settings;
using NUnit.Framework;

namespace MyInventory.API.Test.Service
{
    [TestFixture]
    class OrderServiceTest : BaseServiceTest<OrderService>
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
    }
}
