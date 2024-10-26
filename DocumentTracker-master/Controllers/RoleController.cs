using DocumentTrackerWebApi.Data;
using DocumentTrackerWebApi.DTOs;
using DocumentTrackerWebApi.Interfaces;
using DocumentTrackerWebApi.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace DocumentTrackerWebApi.Controllers
{
    [Route("api/[controller]")]

    [ApiController]

    public class RoleController:ControllerBase
    {
        public readonly ApplicationDbContext _context;
        public readonly IRoleRepository _roleRepository;

        public RoleController(ApplicationDbContext context, IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var role = await _roleRepository.GetAllAsync();
            var roleDTO = role.Select(o => o.toRoleDTO());
            return Ok(role);
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {

            var role = await _roleRepository.GetByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role.toRoleDTO());
        }
        [HttpPost]
        public async Task<ActionResult<RoleDTO>> CreateRole([FromBody] CreateRoleDTO roleDTO)
        {
            var roleModel = roleDTO.ToORoleFromCreateDTO();
            await _roleRepository.AddAsync(roleModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = roleModel.Id }, roleModel);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateRole([FromRoute] string id, [FromBody] UpdateRoleDTO updateRoleDto)
        {


            var role = await _roleRepository.UpdateAsync(id, updateRoleDto);
            if (role == null)
            {
                return NotFound(new { Message = $"Office with ID {id} not found." });
            }


            role.Name = updateRoleDto.Name;
            role.Description = updateRoleDto.Description;
            role.Updated = updateRoleDto.Updated = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return Ok(role.toRoleDTO()); // HTTP 204

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOffice([FromRoute]string  id)
        {
            var role = await _roleRepository.DeleteAsync(id);
            if (role == null)
            {
                return NotFound(new { Message = $"Office with ID {id} not found." });
            }

            _context.Role.Remove(role);
            await _context.SaveChangesAsync();

            return NoContent(); // HTTP 204
        }

        // Helper method to check if an office exists
        private async Task<bool> roleExist(string id)
        {

            return await _roleRepository.ExistsAsync(id);
        }

    }
}
