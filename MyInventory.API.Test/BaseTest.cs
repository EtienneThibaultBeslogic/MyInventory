using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using MyInventory.API.Services.Settings;

namespace MyInventory.API.Test
{
    public abstract class BaseTest
    {
        protected ApplicationDbContext DbContext { get; private set; }

        protected IServiceCollection _serviceCollection;

        protected T Get<T>() => _serviceProvider.GetService<T>();
        protected T GetController<T>()
            where T : ControllerBase
        {
            var controller = Get<T>();

            controller.ControllerContext = Get<ControllerContext>();

            return controller;
        }

        private Dictionary<Type, Mock> MockCache;
        protected MockRepository MockRepository;
        private ServiceProvider _serviceProvider;

        protected Mock<T> GetMock<T>() where T : class
        {
            if (!MockCache.ContainsKey(typeof(T)))
            {
                Mock<T> mock = MockRepository.Create<T>();
                MockCache.Add(typeof(T), mock);
                return mock;
            }

            return (Mock<T>)MockCache[typeof(T)];
        }
        protected T GetMockObject<T>() where T : class => GetMock<T>().Object;
        protected void RegisterService<TService, TImpl>(TImpl service)
            where TService : class
            where TImpl : class, TService =>
            _serviceCollection.AddSingleton<TService>(service);
        protected void RegisterService<TService, TImpl>()
            where TService : class
            where TImpl : class, TService =>
            _serviceCollection.AddSingleton<TService, TImpl>();
        protected void RegisterServiceTransient<TService, TImpl>()
            where TService : class
            where TImpl : class, TService =>
            _serviceCollection.AddTransient<TService, TImpl>();
        protected void RegisterService<TService>()
            where TService : class =>
            _serviceCollection.AddSingleton<TService, TService>();
        protected void RegisterMockService<TService>()
            where TService : class =>
            _serviceCollection.AddSingleton((s) => GetMockObject<TService>());

        [SetUp]
        public void Init()
        {
            // Initialize Mock provider
            InitializeMockRepo();

            var controllerContext = InitializeIoC();

            InitializeInMemoryEntities(controllerContext);

            BaseClassRegistration();
            RegisterServices();

            FinalizeIoC();

            OnInit();

        }

        private void FinalizeIoC()
        {
            _serviceProvider = _serviceCollection.BuildServiceProvider();
        }

        private void InitializeMockRepo()
        {
            MockCache = new Dictionary<Type, Mock>();
            MockRepository = new MockRepository(MockBehavior.Default);
        }

        private ControllerContext InitializeIoC()
        {
            this._serviceCollection = new DefaultServiceProviderFactory().CreateBuilder(new ServiceCollection());
            Assembly assembly = typeof(Startup).GetTypeInfo().Assembly;
            this._serviceCollection
                .AddMvcCore()
                .AddApplicationPart(assembly)
                .AddControllersAsServices();

            var controllerContext = new ControllerContext();
            controllerContext.HttpContext = new DefaultHttpContext();

            RegisterService<ControllerContext, ControllerContext>(controllerContext);
            RegisterService<HttpContext, HttpContext>(controllerContext.HttpContext);
            RegisterService<HttpRequest, HttpRequest>(controllerContext.HttpContext.Request);
            RegisterService<HttpResponse, HttpResponse>(controllerContext.HttpContext.Response);

            RegisterMockService<IHttpContextAccessor>();
            RegisterMockService<HttpRequest>();

            return controllerContext;
        }

        protected abstract void BaseClassRegistration();
        protected abstract void RegisterServices();
        protected abstract void OnInit();

        private void InitializeInMemoryEntities(ControllerContext context)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDB")
                .EnableSensitiveDataLogging()
                .ConfigureWarnings(w => w.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;


            var httpContextAccessorMock = GetMock<IHttpContextAccessor>();

            httpContextAccessorMock.Setup(x => x.HttpContext)
                .Returns(context.HttpContext);

            DbContext = new ApplicationDbContext(options);

            // reset the database
            DbContext.Database.EnsureDeleted();
            DbContext.Database.EnsureCreated();

            RegisterService<ApplicationDbContext, ApplicationDbContext>(DbContext);
            _serviceCollection.AddTransient(typeof(IRepository<>), typeof(EntityFrameworkRepository<>));
        }

    }

    public abstract class BaseControllerTest<T> : BaseTest
        where T : ControllerBase
    {
        protected T Controller { get; set; }

        protected override void OnInit()
        {
            Controller = GetController<T>();
        }

        protected sealed override void BaseClassRegistration()
        {
        }
    }

    public abstract class BaseServiceTest<T> : BaseTest
        where T : class
    {
        protected T Service { get; set; }

        protected override void OnInit()
        {
            Service = Get<T>();
        }
        protected sealed override void BaseClassRegistration()
        {
            RegisterService<T, T>();
        }
    }

    public static class AssertExtensions
    {
        public static IActionResult ShouldBeOk(this IActionResult response)
        {
            var expectedResultType = new[]{
                typeof(OkResult),
                typeof(OkObjectResult)
            };

            Assert.IsTrue(expectedResultType.Contains(response.GetType()), "Expected to be an Ok response");

            return response;
        }

        public static IActionResult ShouldBeBadRequest(this IActionResult response)
        {
            var expectedResultType = new[]{
                typeof(BadRequestResult),
                typeof(BadRequestObjectResult)
            };

            Assert.IsTrue(expectedResultType.Contains(response.GetType()), "Expected to be a bad request response");

            return response;
        }

        public static ActionResult<T> ShouldBeNotFound<T>(this ActionResult<T> response)
        {
            var expectedResultType = new[]{
                typeof(NotFoundResult),
                typeof(NotFoundObjectResult)
            };

            Assert.IsTrue(expectedResultType.Contains(response.Result.GetType()), "Expected to be a not found response");

            return response;
        }

        public static T ShouldBe<T>(this T actual, T expected)
        {

            Assert.AreEqual(expected, actual);

            return actual;
        }

        public static T ShouldNotBe<T>(this T actual, T expected)
        {

            Assert.AreNotEqual(expected, actual);

            return actual;
        }

        public static bool ShouldBeTrue(this bool actual)
        {

            Assert.IsTrue(actual);

            return actual;
        }

        public static bool ShouldBeFalse(this bool actual)
        {

            Assert.IsFalse(actual);

            return actual;
        }
    }
}