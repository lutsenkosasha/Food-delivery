using AutoMapper;
using FoodDelivery.BL.Dishes;
using FoodDelivery.BL.Dishes.Entities;
using FoodDelivery.WebAPI.Controllers.Entities.Dishes;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FoodDelivery.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class DishesController : ControllerBase
{
    private readonly IDishesProvider _dishesProvider;
    private readonly IDishesManager _dishesManager;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public DishesController(IDishesProvider dishesProvider, IDishesManager dishesManager, IMapper mapper, ILogger logger)
    {
        _dishesManager = dishesManager;
        _dishesProvider = dishesProvider;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult GetAllDishes()
    {
        var dishes = _dishesProvider.GetDishes();
        return Ok(new DishesListResponse()
        {
            Dishes = dishes.ToList()
        });
    }

    [HttpGet]
    [Route("filter")]
    public IActionResult GetFilteredDishes([FromQuery] DishesFilter filter)
    {
        var dishes = _dishesProvider.GetDishes(_mapper.Map<DishesModelFilter>(filter));
        return Ok(new DishesListResponse()
        {
            Dishes = dishes.ToList()
        });
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetDishInfo([FromRoute] Guid id)
    {
        try
        {
            var dish = _dishesProvider.GetDishInfo(id);
            return Ok(dish);
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex.ToString()); // stack trace + message
            return NotFound(ex.Message); 
        }
        // Коды ошибок: 200 - все успешно, 404 - не найдено, 401 - не пройдена авторизация
        // 403 - запрещен доступ, 402 - не оплачена какая-то лицензия, 500 - внутренняя ошибка
    }

    [HttpPost]
    public IActionResult CreateDish([FromBody] CreateDishRequest request)
    {
        try
        {
            var dish = _dishesManager.CreateDish(_mapper.Map<CreateDishModel>(request));
            return Ok(dish);
        }
        catch(ArgumentException ex)
        {
            _logger.LogError(ex.ToString());
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult UpdateDishInfo([FromRoute] Guid id, [FromBody] UpdateDishRequest request)
    {
        try
        {
            DishModel dish = _dishesManager.UpdateDish(id, _mapper.Map<UpdateDishModel>(request));
            return Ok(dish);
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex.ToString());
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult DeleteDish([FromRoute] Guid id)
    {
        try
        {
            _dishesManager.DeleteDish(id);
            return Ok();
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex.ToString());
            return BadRequest(ex.Message);
        }
    }
}
