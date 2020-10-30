using Microsoft.EntityFrameworkCore;
using MyBrokenPage.Dal.Contracts;
using MyBrokenPage.Dal.Models;
using System.Linq;

namespace MyBrokenPage.Dal.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(MyBrokenPageContext myBrokenPageContext) : base(myBrokenPageContext) { }

        public IQueryable<Post> GetAll(string search)
        {
            var query = _entities.Include(p => p.User)
                                 .ThenInclude(u => u.Role)
                                 .OrderByDescending(p => p.Id);

            return string.IsNullOrEmpty(search)
                ? query
                : query.Where(p => p.Content.Contains(search));
        }

        public Post GetById(int id)
        {
            return _entities.Include(p => p.User)
                            .ThenInclude(u => u.Role)
                            .Where(p => p.Id == id)
                            .SingleOrDefault();
        }
    }
}
