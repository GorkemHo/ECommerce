﻿using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ECommerce.Domain.Repositories
{
    public interface IBaseRepo<T> where T : IBaseEntity
    {
        Task CreateAsync(T entity); //Metot sonuna Async eklenebilir.
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> GetDefault(Expression<Func<T, bool>> expression);
        Task<List<T>> GetDefaults(Expression<Func<T, bool>> expression);
        Task<bool> Any(Expression<Func<T, bool>> expression);
        Task<TResult> GetFilteredFirstOrDefault<TResult>(Expression<Func<T, TResult>> select,
                                                         Expression<Func<T, bool>> where,
                                                         Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,
                                                         Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        Task<List<TResult>> GetFilteredList<TResult>(Expression<Func<T, TResult>> select,
                                                         Expression<Func<T, bool>> where,
                                                         Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,
                                                         Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
    }
}
