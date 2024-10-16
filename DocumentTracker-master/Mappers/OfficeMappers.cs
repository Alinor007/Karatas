using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentTrackerWebApi.DTOs;
using DocumentTrackerWebApi.Models;

namespace DocumentTrackerWebApi.Mappers
{
    public static class OfficeMappers
    {
        
        public static OfficeDTO ToOfficeDto (this Office officeModel){
            return new OfficeDTO{
                    Id = officeModel.Id,
                    Name = officeModel.Name,
                    Stage = officeModel.Stage,
                    Description = officeModel.Description,
                    Created = officeModel.Created,
                    Updated = officeModel.Updated
            };
        }
        public static Office ToOfficeFromCreateDTO( this CreateOfficeDTO officeDTO){
           
           return new Office{
                    Name = officeDTO.Name,
                    Stage = officeDTO.Stage,
                    Description = officeDTO.Description,
                    Created = officeDTO.Created = DateTime.UtcNow
                    
                 };
        }
    }
}