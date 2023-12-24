using FoodDelivery.WebAPI.Controllers.Entities.Orders;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAllOrders()
    {
        return Ok();
    }

    [HttpGet]
    [Route("filter")]
    public IActionResult GetFilteredOrders([FromQuery] OrdersFilter filter)
    {
        return Ok();
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetOrderInfo([FromRoute] Guid id)
    {
        return Ok();
    }

    [HttpPost]
    public IActionResult CreateOrder([FromBody] CreateOrderRequest request)
    {
        return Ok();
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult UpdateOrderInfo([FromRoute] Guid id, [FromBody] UpdateOrderRequest request)
    {
        return Ok();
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult DeleteOrder([FromRoute] Guid id)
    {
        return Ok();
    }
}
