using FoodDelivery.BL.Users.Entities;

namespace FoodDelivery.WebAPI.Controllers.Entities.Users;

public class UsersListResponse
{
    public List<UserModel> Users { get; set; }
}
