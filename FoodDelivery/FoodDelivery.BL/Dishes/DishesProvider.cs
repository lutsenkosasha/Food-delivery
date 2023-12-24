using AutoMapper;
using FoodDelivery.BL.Dishes.Entities;
using FoodDelivery.DataAccess;
using FoodDelivery.DataAccess.Entities;

namespace FoodDelivery.BL.Dishes;

public class DishesProvider : IDishesProvider
{
    private readonly IRepository<DishEntity> _dishRepository;
    private readonly IMapper _mapper;

    public DishesProvider(IRepository<DishEntity> dishesRepository, IMapper mapper)
    {
        _dishRepository = dishesRepository;
        _mapper = mapper;
    }

    public IEnumerable<DishModel> GetDishes(DishesModelFilter filter = null)
    {
        var minimumPrice = filter?.minimumPrice;
        var maximumPrice = filter?.maximumPrice;
        var minimumNumberOfGrams = filter?.minimumNumberOfGrams;
        var maximumNumberOfGrams = filter?.maximumNumberOfGrams;

        var dishes = _dishRepository.GetAll(x =>
            (minimumPrice == null || x.Price >= minimumPrice) &&
            (maximumPrice == null || x.Price <= maximumPrice) &&
            (minimumNumberOfGrams == null || x.NumberOfGrams >= minimumNumberOfGrams) &&
            (maximumNumberOfGrams == null || x.NumberOfGrams <= maximumNumberOfGrams));

        return _mapper.Map<IEnumerable<DishModel>>(dishes);
    }

    public DishModel GetDishInfo(Guid dishId)
    {
        DishEntity? dish = _dishRepository.GetById(dishId);
        if (dish == null)
        {
            throw new ArgumentException("There is no position for the specified id");
        }

        return _mapper.Map<DishModel>(dish);
    }
}
