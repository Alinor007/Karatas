using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentTrackerWebApi.Data;
using DocumentTrackerWebApi.DTOs;
using DocumentTrackerWebApi.Interfaces;
using DocumentTrackerWebApi.Mappers;
using DocumentTrackerWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DocumentTrackerWebApi.Controllers
{
    [Route("api/Office")]
    [ApiController]

    public class OfficesController:ControllerBase
    {
        public readonly ApplicationDbContext _context;
         public readonly IOfficeRepository _OfficeRepo;
        public OfficesController(ApplicationDbContext context, IOfficeRepository officeRepository)
        {
            _OfficeRepo= officeRepository;
            _context = context;
       }

       [HttpGet]
       public async Task< IActionResult >GetAll(){
        var Office  = await _OfficeRepo.GetAllAsync();
        var officeDTO = Office.Select(o=>o.ToOfficeDto());
        return Ok(Office);
       }
       [HttpGet("{id:int}")]
       public async Task<IActionResult> GetById([FromRoute] int id){

        var Office = await _OfficeRepo.GetByIdAsync(id);
        if (Office == null){
            return NotFound();
        }
        return Ok(Office.ToOfficeDto());
       }
       // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
      public async Task<ActionResult<OfficeDTO>> CreateOffice ([FromBody] CreateOfficeDTO officeDTO)
        {
            var officeModel = officeDTO.ToOfficeFromCreateDTO();
            await _OfficeRepo.AddAsync(officeModel);
           await _context.SaveChangesAsync();

           return CreatedAtAction(nameof(GetById),new {id= officeModel.Id},officeModel);
        }
          // PUT: api/offices/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOffice([FromRoute]int id, [FromBody] UpdateOfficeDTO updateOfficeDto)
        {
            

            var officeModel = await _OfficeRepo.UpdateAsync(id,updateOfficeDto);
            if (officeModel == null)
            {
                return NotFound(new { Message = $"Office with ID {id} not found." });
            }
             

                officeModel.Name = updateOfficeDto.Name;
                officeModel.Stage = updateOfficeDto.Stage;
                officeModel.Description = updateOfficeDto.Description;
                officeModel.Updated = updateOfficeDto.Updated = DateTime.UtcNow;
                await _context.SaveChangesAsync();

            return Ok(officeModel.ToOfficeDto()); // HTTP 204
        }

        // DELETE: api/offices/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOffice([FromRoute]int id)
        {
            var officeModel = await _OfficeRepo.DeleteAsync(id);
            if (officeModel == null)
            {
                return NotFound(new { Message = $"Office with ID {id} not found." });
            }

            _context.Offices.Remove(officeModel);
            await _context.SaveChangesAsync();

            return NoContent(); // HTTP 204
        }

        // Helper method to check if an office exists
        private async Task<bool> OfficeExists(int id)
        {

            return await _OfficeRepo.ExistsAsync(id);
        }
    }
    }