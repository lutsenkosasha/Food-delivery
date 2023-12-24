using FoodDelivery.WebAPI.Controllers.Entities.Deliveries;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class DeliveriesController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAllDeliveries()
    {
        return Ok();
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetDeliveryInfo([FromRoute] Guid id)
    {
        return Ok();
    }

    [HttpPost]
    public IActionResult CreateDelivery([FromBody] CreateDeliveryRequest request)
    {
        return Ok();
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult UpdateDeliveryInfo([FromRoute] Guid id, [FromBody] UpdateDeliveryRequest request)
    {
        return Ok();
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult DeleteDelivery([FromRoute] Guid id)
    {
        return Ok();
    }
}
