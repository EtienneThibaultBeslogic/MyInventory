namespace MyInventory.API.Services
{
    public interface IPriceService
    {
        public double CalculatePrice(double width, double length);
    }

    public class PriceService : IPriceService
    {
        private readonly IShapeService _shapeService;

        public PriceService(IShapeService shapeService)
        {
            _shapeService = shapeService;
        }

        public double CalculatePrice(double width, double length)
        {
            var pricePerMeterSquare = 1.5;
            var area = _shapeService.CalculateArea(width, length);
            return pricePerMeterSquare * area;
        }
    }
}
