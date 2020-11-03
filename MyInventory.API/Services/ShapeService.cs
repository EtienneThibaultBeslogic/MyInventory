using System.Collections.Generic;
using System.Linq;
using MyInventory.API.Models;
using MyInventory.API.Models.Dtos;
using MyInventory.API.Services.Settings;

namespace MyInventory.API.Services
{
    public interface IShapeService
    {
        public double CalculateArea(double x, double y);
        List<ShapeDto> GetShapes();
        ShapeDto InsertShape(ShapeDto shapeDto);
    }

    public class ShapeService : IShapeService
    {
        private readonly IRepository<Shape> _shapeRepo;

        public ShapeService(
            IRepository<Shape> shapeRepo
            )
        {
            _shapeRepo = shapeRepo;
        }

        public double CalculateArea(double x, double y)
        {
            var area = x * y;
            return area;
        }

        public List<ShapeDto> GetShapes()
        {
            return _shapeRepo.Select(ShapeDto.ToDto).ToList();
        }

        public ShapeDto InsertShape(ShapeDto shapeDto)
        {
            var shape = _shapeRepo.Create(new Shape
            {
                Name = shapeDto.Name,
                Width = shapeDto.Width,
                Length = shapeDto.Length
            });

            return ShapeDto.ToDto(shape);
        }
    }
}
