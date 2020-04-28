using MyBrokenPage.Dal.Models;
using MyBrokenPage.Models;

namespace MyBrokenPage.Bll.Converters
{
    public static class RoleModelConverters
    {
        public static RoleModel ToRoleModel(this Role role)
        {
            return role == null ? null : new RoleModel { Id = role.Id, Name = role.Name };
        }
    }
}
