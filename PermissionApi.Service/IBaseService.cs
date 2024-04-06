using AutoMapper;
using FluentValidation;
using PermissionManagement.Model.Entities;
using PermissionManagement.Repository;
using PermissionManagement.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PermissionManagement.Service
{
    public interface IBaseService<Entity>
    {
        Task<int> AddAsync(Entity entity);
        Task UpdateAsync(Entity entity);
        Task RemoveAsync(int key);
        Task<Entity> GetByIdAsync(int key);
        Task<IEnumerable<Entity>> GetAllAsync();
    }
    public class BaseService<Entity, EntityDto> : IBaseService<EntityDto>
        where EntityDto : class, IBaseDto
        where Entity : class, IBaseEntity
    {
        private readonly IValidator<EntityDto> _validator;
        protected readonly IMapper _mapper;
        protected readonly IBaseRepository<Entity> _repository;
        public BaseService(
            IBaseRepository<Entity> repository,
            IMapper mapper,
            IValidator<EntityDto> validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }
        public virtual async Task<int> AddAsync(EntityDto dto)
        {
            var result = _validator.Validate(dto);
            var record = await _repository.GetByIdAsync(dto.Id);
            if (record != null || !result.IsValid)
                throw new InvalidOperationException("This entity already exist or is invalid.");

            var entity = _mapper.Map<Entity>(dto);
            return await _repository.AddAsync(entity);
        }

        public virtual async Task<IEnumerable<EntityDto>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();
            var entityDtos = _mapper.Map<IEnumerable<EntityDto>>(result);
            return entityDtos;
        }

        public virtual async Task<EntityDto> GetByIdAsync(int key)
        {
            var entity = await _repository.GetByIdAsync(key);
            var dto = _mapper.Map<EntityDto>(entity);
            return dto;
        }

        public virtual async Task RemoveAsync(int key)
        {
            var record = await _repository.GetByIdAsync(key);

            if (record == null)
                throw new InvalidOperationException("This entity doesn't exist.");

            await _repository.RemoveAsync(key);
        }

        public virtual async Task UpdateAsync(EntityDto dto)
        {
            var result = _validator.Validate(dto);
            var entity = await _repository.GetByIdAsync(dto.Id);

            if (entity == null || !result.IsValid)
                throw new InvalidOperationException("This entity doesn't exist or is invalid.");


            var newEntity = _mapper.Map(dto, entity);
            await _repository.UpdateAsync(newEntity);
        }
    }
}
