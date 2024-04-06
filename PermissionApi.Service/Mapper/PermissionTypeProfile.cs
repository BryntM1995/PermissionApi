using AutoMapper;
using PermissionManagement.Model.Entities;
using PermissionManagement.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PermissionManagement.Service.Mapper
{
    public class PermissionTypeProfile : Profile
    {
        public PermissionTypeProfile()
        {
            CreateMap<PermissionTypeDto, PermissionType>();
            CreateMap<PermissionType, PermissionTypeDto>();
        }
    }
}
