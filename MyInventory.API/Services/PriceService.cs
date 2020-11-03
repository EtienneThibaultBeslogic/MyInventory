namespace MyInventory.API.Services
{
    public interface IPriceService
    {
        public double CalculatePrice(double width, double length);
    }

    public class PriceService : IPriceService
    {
        private readonly IShapeService _shapeService;
        private const double _pricePerSquareMeter = 1.5;

        public PriceService(IShapeService shapeService)
        {
            _shapeService = shapeService;
        }

        public double CalculatePrice(double width, double length)
        {
            var area = _shapeService.CalculateArea(width, length);
            return _pricePerSquareMeter * area;
        }
    }
}
