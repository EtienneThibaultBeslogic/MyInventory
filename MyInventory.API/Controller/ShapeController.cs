using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MyInventory.API.Models.Dtos;
using MyInventory.API.Services;

namespace MyInventory.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShapeController : ControllerBase
    {
        private readonly IShapeService _shapeService;
        public ShapeController(IShapeService shapeService)
        {
            _shapeService = shapeService;
        }

        [HttpGet]
        public List<ShapeDto> GetShapes()
        {
            return _shapeService.GetShapes();
        }

        [HttpPut]
        public ShapeDto InsertShape(ShapeDto shapeDto)
        {
            return _shapeService.InsertShape(shapeDto);
        }
    }
}
