using FoodDelivery.BL.Users.Entities;

namespace FoodDelivery.BL.Users;

public interface IUsersProvider
{
    IEnumerable<UserModel> GetUsers();
    UserModel GetUserInfo(Guid userId);
}
