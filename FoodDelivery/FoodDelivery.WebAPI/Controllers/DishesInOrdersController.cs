using FoodDelivery.WebAPI.Controllers.Entities.DishesInOrders;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class DishesInOrdersController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAllDishesInOrders()
    {
        return Ok();
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetDishInOrderInfo([FromRoute] Guid id)
    {
        return Ok();
    }

    [HttpPost]
    public IActionResult CreateDishInOrder([FromBody] CreateDishInOrderRequest request)
    {
        return Ok();
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult UpdateDishInOrderInfo([FromRoute] Guid id, [FromBody] UpdateDishInOrderRequest request)
    {
        return Ok();
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult DeleteDishInOrder([FromRoute] Guid id)
    {
        return Ok();
    }
}
