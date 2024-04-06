using PermissionManagement.Model.Context;
using PermissionManagement.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PermissionManagement.Repository
{
    public interface IPermissionTypeRepository : IBaseRepository<PermissionType> { }
    public class PermissionTypeRepository : BaseRepository<PermissionType>, IPermissionTypeRepository
    {
        public PermissionTypeRepository(PermissionContext dbContext) : base(dbContext)
        {

        }
    }
}
