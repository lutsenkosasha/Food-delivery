using AutoMapper;
using FoodDelivery.BL.Dishes.Entities;
using FoodDelivery.DataAccess;
using FoodDelivery.DataAccess.Entities;

namespace FoodDelivery.BL.Dishes;

public class DishesManager : IDishesManager
{
    private readonly IRepository<DishEntity> _dishesRepository;
    private readonly IMapper _mapper;

    public DishesManager(IRepository<DishEntity> dishesRepository, IMapper mapper)
    {
        _dishesRepository = dishesRepository;
        _mapper = mapper;
    }

    public DishModel CreateDish(CreateDishModel model)
    {
        DishEntity entity = _mapper.Map<DishEntity>(model);
        _dishesRepository.Save(entity);
        return _mapper.Map<DishModel>(entity);
    }

    public void DeleteDish(Guid dishId)
    {
        DishEntity? entity = _dishesRepository.GetById(dishId);
        if (entity == null)
        {
            throw new ArgumentException("There is no position for the specified id");
        }
        _dishesRepository.Delete(entity);
    }

    public DishModel UpdateDish(Guid dishId, UpdateDishModel model)
    {
        DishEntity? entity = _dishesRepository.GetById(dishId);
        if (entity == null)
        {
            throw new ArgumentException("There is no position for the specified id");
        }
        DishEntity newEntity = _mapper.Map<DishEntity>(model);
        newEntity.Id = entity.Id;
        newEntity.ExternalId = entity.ExternalId;
        newEntity.CreationTime = entity.CreationTime;
        newEntity.ModificationTime = entity.ModificationTime;

        _dishesRepository.Save(newEntity);
        return _mapper.Map<DishModel>(newEntity);
    }
}
