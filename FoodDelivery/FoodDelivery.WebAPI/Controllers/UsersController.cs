using FoodDelivery.WebAPI.Controllers.Entities.Users;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    [HttpPost]
    public IActionResult RegisterUser([FromBody] RegisterUserRequest request)
    {
        return Ok();
    }

    [HttpGet]
    public IActionResult GetAllUsers()
    {
        return Ok();
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetUserInfo([FromRoute] Guid id)
    {
        return Ok();
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult UpdateUserInfo([FromRoute] Guid id, [FromBody] UpdateUserRequest request)
    {
        return Ok();
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult DeleteUser([FromRoute] Guid id)
    {
        return Ok();
    }
}
