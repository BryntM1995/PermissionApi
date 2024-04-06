using PermissionManagement.Model.Context;
using PermissionManagement.Model.Entities;

namespace PermissionManagement.Repository
{

    public interface IPermissionRepository : IBaseRepository<Permission> { }
    public class PermissionRepository : BaseRepository<Permission>, IPermissionRepository
    {
        public PermissionRepository(PermissionContext dbContext) : base(dbContext)
        {

        }
    }
}
