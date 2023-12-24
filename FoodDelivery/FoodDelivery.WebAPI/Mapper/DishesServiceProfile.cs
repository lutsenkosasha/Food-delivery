using AutoMapper;
using FoodDelivery.BL.Dishes.Entities;
using FoodDelivery.WebAPI.Controllers.Entities.Dishes;

namespace FoodDelivery.WebAPI.Mapper;

public class DishesServiceProfile : Profile
{
    public DishesServiceProfile()
    {
        CreateMap<DishesFilter, DishesModelFilter>();
        CreateMap<CreateDishRequest, CreateDishModel>();
    }
}
