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
    public interface IPermissionTypeService : IBaseService<PermissionTypeDto> { }
    public class PermissionTypeService : BaseService<PermissionType, PermissionTypeDto>, IPermissionTypeService
    {
        public PermissionTypeService(IBaseRepository<PermissionType> _repository, IMapper mapper, IValidator<PermissionTypeDto> validator) : base(_repository, mapper, validator)
        {
        }

    }
}
