using AutoMapper;
using FoodDelivery.BL.Users.Entities;
using FoodDelivery.DataAccess;
using FoodDelivery.DataAccess.Entities;

namespace FoodDelivery.BL.Users;

public class UsersProvider : IUsersProvider
{
    private readonly IRepository<UserEntity> _userRepository;
    private readonly IMapper _mapper;

    public UsersProvider(IRepository<UserEntity> userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public UserModel GetUserInfo(Guid userId)
    {
        UserEntity? user = _userRepository.GetById(userId);
        if (user == null)
        {
            throw new ArgumentException("There is no position for the specified id");
        }
        return _mapper.Map<UserModel>(user);
    }

    public IEnumerable<UserModel> GetUsers()
    {
        IEnumerable<UserEntity> users = _userRepository.GetAll();
        return _mapper.Map<IEnumerable<UserModel>>(users);
    }
}
