using Microsoft.AspNetCore.Mvc;

namespace MyInventory.API.Services.Settings
{
  [Route("api/[controller]")]
  [ApiController]
  public abstract class ApiControllerBase : ControllerBase
  {
    public IActionResult Json(object obj)
    {
      return new JsonResult(obj);
    }
  }

}
