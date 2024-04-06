using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PermissionManagement.Model.Entities;
using PermissionManagement.Service;
using PermissionManagement.Service.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PermissionManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionTypeController : ControllerBase
    {
        private readonly IBaseService<PermissionTypeDto> _PermissionTypeService;

        public PermissionTypeController(IBaseService<PermissionTypeDto> permissionTypeService)
        {
            _PermissionTypeService = permissionTypeService;
        }

        [HttpGet]
        public async Task<IEnumerable<PermissionTypeDto>> GetAll()
        {
            return await _PermissionTypeService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<PermissionTypeDto> GetById([FromRoute] int id)
        {
            return await _PermissionTypeService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<int> Add([FromBody] PermissionTypeDto value)
        {
           var id = await _PermissionTypeService.AddAsync(value);
           return id;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] PermissionTypeDto value)
        {
            if (id != value.Id)
                return BadRequest();

            await _PermissionTypeService.UpdateAsync(value);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task Remove([FromRoute] int id)
        {
            await _PermissionTypeService.RemoveAsync(id);
        }
    }
}
