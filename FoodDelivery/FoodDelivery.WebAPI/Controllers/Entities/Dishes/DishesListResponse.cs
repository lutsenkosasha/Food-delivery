using FoodDelivery.BL.Dishes.Entities;

namespace FoodDelivery.WebAPI.Controllers.Entities.Dishes;

public class DishesListResponse
{
    public List<DishModel> Dishes { get; set; }
}
