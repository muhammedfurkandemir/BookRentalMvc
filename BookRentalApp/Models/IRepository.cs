﻿using System.Linq.Expressions;

namespace BookRentalApp.Models
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        T Get(Expression<Func<T, bool>> filter);

        void Update(T entity);

        void Delete(T entity);

        void DeleteRange(IEnumerable<T> Entities);
    }
}
