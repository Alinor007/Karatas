using DocumentTracker.Models;
using DocumentTrackerWebApi.DTOs;
using DocumentTrackerWebApi.Models;

namespace DocumentTrackerWebApi.Mappers
{
    public  static class RoleMappers
    {

        public static RoleDTO toRoleDTO(this Role RoleModel)
        {
            return new RoleDTO
            {
                Id = RoleModel.Id,
                Name = RoleModel.Name,
                Description = RoleModel.Description,
                Created = RoleModel.Created,
                Updated = RoleModel.Updated,
            };
        }
        public static Role ToORoleFromCreateDTO(this CreateRoleDTO roleDTO)
        {

            return new Role
            {
                Name = roleDTO.Name,
                Description = roleDTO.Description,

            };
        }
    }
}
