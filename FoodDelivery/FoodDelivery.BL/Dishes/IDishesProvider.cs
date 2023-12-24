using FoodDelivery.BL.Dishes.Entities;

namespace FoodDelivery.BL.Dishes;

public interface IDishesProvider
{
    IEnumerable<DishModel> GetDishes(DishesModelFilter filter = null);
    DishModel GetDishInfo(Guid dishId);
}
