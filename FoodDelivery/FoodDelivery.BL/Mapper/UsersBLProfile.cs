using AutoMapper;
using FoodDelivery.BL.Dishes.Entities;
using FoodDelivery.BL.Users.Entities;
using FoodDelivery.DataAccess.Entities;

namespace FoodDelivery.BL.Mapper;

public class UsersBLProfile : Profile
{
    public UsersBLProfile()
    {
        CreateMap<UserEntity, UserModel>()
            .ForMember(x => x.Id, y => y.MapFrom(src => src.ExternalId));

        CreateMap<UpdateUserModel, UserEntity>()
            .ForMember(x => x.Id, y => y.Ignore())
            .ForMember(x => x.ExternalId, y => y.Ignore())
            .ForMember(x => x.ModificationTime, y => y.Ignore())
            .ForMember(x => x.CreationTime, y => y.Ignore());
    }
}
