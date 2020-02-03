using Microsoft.EntityFrameworkCore;
using MyBrokenPage.Dal.Contratcs;
using System.Linq;

namespace MyBrokenPage.Dal.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
        protected MyBrokenPageContext _myPageContext;

        protected DbSet<T> _entities;

        public GenericRepository(MyBrokenPageContext myPageContext)
        {
            _myPageContext = myPageContext;
            _entities = _myPageContext.Set<T>();
        }

        public void Add(T entity)
        {
            _entities.Add(entity);
        }

        public void Delete(T entity)
        {
            _entities.Remove(entity);
        }

        public IQueryable<T> GetAll()
        {
            return _entities;
        }

        public T Update(T entity)
        {
            return _entities.Update(entity).Entity;
        }

        public void SaveChanges()
        {
            _myPageContext.SaveChanges(true);
        }
    }
}
