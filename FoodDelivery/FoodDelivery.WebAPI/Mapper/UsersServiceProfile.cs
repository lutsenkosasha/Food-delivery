using AutoMapper;
using FoodDelivery.BL.Auth.Entities;
using FoodDelivery.BL.Users.Entities;
using FoodDelivery.WebAPI.Controllers.Entities.Users;

namespace FoodDelivery.WebAPI.Mapper;

public class UsersServiceProfile : Profile
{
    public UsersServiceProfile()
    {
        CreateMap<UpdateUserRequest, UpdateUserModel>();
        CreateMap<RegisterUserRequest, RegisterUserModel>();
    }
}
