using FoodDelivery.DataAccess.Entities;
using System.Linq.Expressions;

namespace FoodDelivery.DataAccess;

public interface IRepository<T> where T : BaseEntity
{
    IEnumerable<T> GetAll(); // Получить все записи
    IEnumerable<T> GetAll(Expression<Func<T, bool>> filter); // Получить все записи по фильтру
    T? GetById(int id);
    T? GetById(Guid id);
    T Save(T entity);
    void Delete(T entity);
}
