using System.Linq;

namespace MyBrokenPage.Dal.Contratcs
{
    public interface IGenericRepository<T> where T : class, new()
    {
        void Add(T entity);

        IQueryable<T> GetAll();

        void Delete(T entity);

        T Update(T entity);

        void SaveChanges();
    }
}
