﻿using FoodDelivery.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FoodDelivery.DataAccess;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    public Repository(IDbContextFactory<FoodDeliveryDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public IEnumerable<T> GetAll()
    {
        using var context = _contextFactory.CreateDbContext();
        return context.Set<T>().ToList();
    }

    public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter)
    {
        using var context = _contextFactory.CreateDbContext();
        return context.Set<T>().Where(filter).ToList();
    }

    public IEnumerable<T> GetAll<TKey>(Expression<Func<T, TKey>> keySelector)
    {
        using var context = _contextFactory.CreateDbContext();
        return context.Set<T>().OrderBy(keySelector).ToList();
    }

    public T? GetById(int id)
    {
        using var context = _contextFactory.CreateDbContext();
        return context.Set<T>().FirstOrDefault(x => x.Id == id);
    }

    public T? GetById(Guid id)
    {
        using var context = _contextFactory.CreateDbContext();
        return context.Set<T>().FirstOrDefault(x => x.ExternalId == id);
    }

    public T Save(T entity)
    {
        using var context = _contextFactory.CreateDbContext();
        if (context.Set<T>().Any(x => x.Id == entity.Id))
        {
            entity.ModificationTime = DateTime.UtcNow;
            var result = context.Set<T>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
            return result.Entity;
        }
        else
        {
            entity.ExternalId = Guid.NewGuid();
            entity.CreationTime = DateTime.UtcNow;
            entity.ModificationTime = entity.CreationTime;
            var result = context.Set<T>().Add(entity);
            context.SaveChanges();
            return result.Entity;
        }
    }

    public void Delete(T entity)
    {
        using var context = _contextFactory.CreateDbContext();
        context.Set<T>().Attach(entity);
        context.Entry(entity).State = EntityState.Deleted;
        context.SaveChanges();
    }

    private readonly IDbContextFactory<FoodDeliveryDbContext> _contextFactory;
}
