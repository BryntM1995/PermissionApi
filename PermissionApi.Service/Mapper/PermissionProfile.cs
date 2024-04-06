using AutoMapper;
using PermissionManagement.Model.Entities;
using PermissionManagement.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PermissionManagement.Service.Mapper
{
    public class PermissionProfile : Profile
    {
        public PermissionProfile()
        {
            CreateMap<PermissionDto, Permission>();
            CreateMap<Permission, PermissionDto>().ForMember(d => d.PermissionTypeName, m => m.MapFrom(s=> s.PermissionType.Description));
        }
    }
}
