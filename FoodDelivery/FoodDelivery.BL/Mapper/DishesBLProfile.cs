using AutoMapper;
using FoodDelivery.BL.Dishes.Entities;
using FoodDelivery.DataAccess.Entities;

namespace FoodDelivery.BL.Mapper;

public class DishesBLProfile : Profile
{
    public DishesBLProfile()
    {
        CreateMap<DishEntity, DishModel>()
            .ForMember(x => x.Id, y => y.MapFrom(src => src.ExternalId));

        CreateMap<CreateDishModel, DishEntity>()
            .ForMember(x => x.Id, y => y.Ignore())
            .ForMember(x => x.ExternalId, y => y.Ignore())
            .ForMember(x => x.ModificationTime, y => y.Ignore())
            .ForMember(x => x.CreationTime, y => y.Ignore());

        CreateMap<UpdateDishModel, DishEntity>()
            .ForMember(x => x.Id, y => y.Ignore())
            .ForMember(x => x.ExternalId, y => y.Ignore())
            .ForMember(x => x.ModificationTime, y => y.Ignore())
            .ForMember(x => x.CreationTime, y => y.Ignore());
    }
}
