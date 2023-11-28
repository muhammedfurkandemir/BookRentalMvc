using BookRentalApp.Utility;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookRentalApp.Models
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly RentalBookContext _rentalBookContext;
        internal DbSet<T> dbSet;

        public Repository(RentalBookContext rentalBookContext)
        {
            _rentalBookContext = rentalBookContext;
            dbSet =_rentalBookContext.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> Entities)
        {
            dbSet.RemoveRange(Entities);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query=dbSet.Where(filter);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

       
    }
}
