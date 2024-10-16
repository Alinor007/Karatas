using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentTracker.Models;
using DocumentTrackerWebApi.DTOs;
using DocumentTrackerWebApi.Extension;
using DocumentTrackerWebApi.Interfaces;
using DocumentTrackerWebApi.Mappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DocumentTrackerWebApi.Controllers
{
    [Route("api/History")]
    [ApiController]


    public class HistoryController:ControllerBase
    {
         private readonly IHistoryRepository _historyRepo;
        private readonly UserManager<User> _userManager; // Add UserManager

        public HistoryController(IHistoryRepository historyRepo,UserManager<User> userManager )
        {
            _historyRepo = historyRepo;
            _userManager = userManager;
        }

        // GET: api/history
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistoryDTO>>> GetAll()
        {
            var histories = await _historyRepo.GetAllAsync();
            var historiesDto = histories.Select(h => h.ToHistoryDto());
            return Ok(historiesDto);
        }

        // GET: api/history/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<HistoryDTO>> GetById(int id)
        {
            var history = await _historyRepo.GetByIdAsync(id);
            if (history == null)
            {
                return NotFound(new { Message = $"History with ID {id} not found." });
            }
            return Ok(history.ToHistoryDto());
        }

        // POST: api/history
        [HttpPost]
        public async Task<ActionResult<HistoryDTO>> CreateHistory([FromBody] CreateHistoryDTO createHistoryDto)
        {
            var username = User.GetUsername();
            var AppUser = await _userManager.FindByEmailAsync(username);

           

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var historyModel = createHistoryDto.ToHistoryFromCreateDTO();
            historyModel.UserId = AppUser.Id;
            await _historyRepo.AddAsync(historyModel);

            var historyDto = historyModel.ToHistoryDto();
            return CreatedAtAction(nameof(GetById), new { id = historyDto.Id }, historyDto);
        }

        // PUT: api/history/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateHistory(int id, [FromBody] UpdateHistoryDTO updateHistoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedHistory = await _historyRepo.UpdateAsync(id, updateHistoryDto);
            if (updatedHistory == null)
            {
                return NotFound(new { Message = $"History with ID {id} not found or could not be updated." });
            }

            return Ok(updatedHistory.ToHistoryDto());
        }

        // DELETE: api/history/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteHistory(int id)
        {
            var deletedHistory = await _historyRepo.DeleteAsync(id);
            if (deletedHistory == null)
            {
                return NotFound(new { Message = $"History with ID {id} not found." });
            }

            return NoContent(); // HTTP 204
        }
        
    }
}