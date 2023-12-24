using AutoMapper;
using FoodDelivery.BL.Dishes.Entities;
using FoodDelivery.BL.Users.Entities;
using FoodDelivery.DataAccess;
using FoodDelivery.DataAccess.Entities;

namespace FoodDelivery.BL.Users;

public class UsersManager : IUsersManager
{
    private readonly IRepository<UserEntity> _userRepository;
    private readonly IMapper _mapper;

    public UsersManager(IRepository<UserEntity> userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public UserModel CreateUser(CreateUserModel model)
    {
        UserEntity entity = _mapper.Map<UserEntity>(model);
        _userRepository.Save(entity);
        return _mapper.Map<UserModel>(entity);
    }

    public void DeleteUser(Guid userId)
    {
        UserEntity? entity = _userRepository.GetById(userId);
        if (entity == null)
        {
            throw new ArgumentException("There is no position for the specified id");
        }
        _userRepository.Delete(entity);
    }

    public UserModel UpdateUser(Guid userId, UpdateUserModel model)
    {
        UserEntity? entity = _userRepository.GetById(userId);
        if (entity == null)
        {
            throw new ArgumentException("There is no position for the specified id");
        }

        UserEntity newEntity = _mapper.Map<UserEntity>(model);
        newEntity.Id = entity.Id;
        newEntity.ExternalId = entity.ExternalId;
        newEntity.CreationTime = entity.CreationTime;
        newEntity.ModificationTime = entity.ModificationTime;

        _userRepository.Save(entity);
        return _mapper.Map<UserModel>(entity);
    }
}
