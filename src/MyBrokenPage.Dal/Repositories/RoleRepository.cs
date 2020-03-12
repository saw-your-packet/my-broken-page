using MyBrokenPage.Dal.Contracts;
using MyBrokenPage.Dal.Models;
using System.Linq;

namespace MyBrokenPage.Dal.Repositories
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(MyBrokenPageContext myBrokenPageContext) : base(myBrokenPageContext) { }

        public Role GetById(int id)
        {
            return _entities.Where(r => r.Id == id)
                            .SingleOrDefault();
        }
    }
}
