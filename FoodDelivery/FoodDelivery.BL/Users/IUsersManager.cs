using FoodDelivery.BL.Dishes.Entities;
using FoodDelivery.BL.Users.Entities;

namespace FoodDelivery.BL.Users;

public interface IUsersManager
{
    UserModel CreateUser(CreateUserModel model);
    void DeleteUser(Guid userId);
    UserModel UpdateUser(Guid userId, UpdateUserModel model);
}
