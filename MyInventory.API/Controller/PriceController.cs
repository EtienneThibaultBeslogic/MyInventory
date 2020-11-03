using Microsoft.AspNetCore.Mvc;
using MyInventory.API.Services;

namespace MyInventory.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceController : ControllerBase
    {
        private readonly IPriceService _priceService;
        public PriceController(IPriceService priceService)
        {
            _priceService = priceService;
        }

        [HttpGet]
        public double CalculatePrice(double width, double length)
        {
            return _priceService.CalculatePrice(width, length);
        }
    }
}
