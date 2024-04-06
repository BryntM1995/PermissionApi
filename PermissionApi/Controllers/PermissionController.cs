using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PermissionManagement.Service.DTOs;
using PermissionManagement.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PermissionManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IBaseService<PermissionDto> _PermissionService;

        public PermissionController(IBaseService<PermissionDto> permissionService)
        {
            _PermissionService = permissionService;
        }

        [HttpGet]
        public async Task<IEnumerable<PermissionDto>> GetAll()
        {
            return await _PermissionService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<PermissionDto> GetById([FromRoute] int id)
        {
            return await _PermissionService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PermissionDto value)
        {
            await _PermissionService.AddAsync(value);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] PermissionDto value)
        {
            if (id != value.Id)
                return BadRequest();

            await _PermissionService.UpdateAsync(value);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove([FromRoute] int id)
        {
            await _PermissionService.RemoveAsync(id);
            return Ok();
        }
    }
}
