using MyBrokenPage.Dal.Contratcs;
using MyBrokenPage.Dal.Models;
using System.Linq;

namespace MyBrokenPage.Dal.Contracts
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        IQueryable<Post> GetAll(string search);

        Post GetById(int id);
    }
}
