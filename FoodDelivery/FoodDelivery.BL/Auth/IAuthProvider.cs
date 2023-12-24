using FoodDelivery.BL.Auth.Entities;

namespace FoodDelivery.BL.Auth
{
    public interface IAuthProvider
    {
        Task<TokensResponse> AuthorizeUser(string email, string password);
        Task RegisterUser(RegisterUserModel model);
    }
}
