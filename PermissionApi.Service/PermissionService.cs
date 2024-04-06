using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PermissionManagement.Model.Entities;
using PermissionManagement.Repository;
using PermissionManagement.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PermissionManagement.Service
{
    public interface IPermissionService : IBaseService<PermissionDto> {}
    public class PermissionService : BaseService<Permission, PermissionDto>, IPermissionService
    {
        public PermissionService(IBaseRepository<Permission> _repository, IMapper mapper, IValidator<PermissionDto> validator) : base(_repository, mapper, validator)
        {
        }

        public override async Task<IEnumerable<PermissionDto>> GetAllAsync()
        {
            var result = await _repository.Query().Include(x => x.PermissionType).ToListAsync();
            var entityDtos = _mapper.Map<IEnumerable<PermissionDto>>(result);
            return entityDtos;
        }

        public override async Task<PermissionDto> GetByIdAsync(int key)
        {
            var result = await _repository.Query().Include(x => x.PermissionType).FirstOrDefaultAsync(x=> x.Id == key);
            var dto = _mapper.Map<PermissionDto>(result);
            return dto;
        }

    }
}
