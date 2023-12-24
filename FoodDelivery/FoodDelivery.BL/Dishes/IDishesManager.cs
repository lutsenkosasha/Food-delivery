using FoodDelivery.BL.Dishes.Entities;

namespace FoodDelivery.BL.Dishes;

public interface IDishesManager
{
    DishModel CreateDish(CreateDishModel model);
    void DeleteDish(Guid dishId);
    DishModel UpdateDish(Guid dishId, UpdateDishModel model);
}
