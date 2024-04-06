using AutoMapper;
using FluentValidation;
using PermissionManagement.Model.Entities;
using PermissionManagement.Repository;
using PermissionManagement.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PermissionManagement.Service
{
    public interface IPermissionService : IBaseService<PermissionDto> { }
    public class PermissionService : BaseService<Permission, PermissionDto>, IPermissionService
    {
        public PermissionService(IBaseRepository<Permission> _repository, IMapper mapper, IValidator<PermissionDto> validator) : base(_repository, mapper, validator)
        {
        }

    }
}
