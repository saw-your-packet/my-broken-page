using MyBrokenPage.Dal.Contratcs;
using MyBrokenPage.Dal.Models;

namespace MyBrokenPage.Dal.Contracts
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        Role GetById(int id);
    }
}
