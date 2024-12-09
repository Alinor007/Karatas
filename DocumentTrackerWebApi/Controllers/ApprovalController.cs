using DocumentTracker.Models;
using DocumentTrackerWebApi.Data;
using DocumentTrackerWebApi.DTOs;
using DocumentTrackerWebApi.Extension;
using DocumentTrackerWebApi.Interfaces;
using DocumentTrackerWebApi.Mappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DocumentTrackerWebApi.Controllers
{
      [Route("api/[controller]")]

    [ApiController]


    public class ApprovalController : Controller
    {
        private readonly IApproval _approval;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<ApprovalController> _logger;
        private readonly IHistoryRepository _historyRepository;
        public ApprovalController(
            IApproval approval,
            ApplicationDbContext context,
            ILogger<ApprovalController> logger,
            UserManager<User> userManager,
            IHistoryRepository historyRepository)
        {
            _approval = approval;
            _context = context;
            _logger = logger;
            _userManager = userManager;
            _historyRepository = historyRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocumentApprovalDTO>>> GetAll()
        {
            var approvals = await _approval.GetAllAsync();
            var approvalDto = approvals.Select(d => d.ToApprovalDto());
            return Ok(approvalDto);
        }

        // GET: api/documents/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<DocumentApprovalDTO>> GetById(int id)
        {
            var approvals = await _approval.GetByIdAsync(id);
            if (approvals == null)
            {
                return NotFound(new { Message = $"Approval with ID {id} not found." });
            }
            return Ok(approvals.ToApprovalDto());
        }
        // POST: api/documents
        [HttpPost("{id:int}/approveOrDecline")]
        public async Task<ActionResult> ApproveOrDecline(int id, [FromQuery] bool isApproved, [FromBody] CreateHistoryDTO createHistoryDto)
        {

            var AppUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var HistoryModel = createHistoryDto.ToHistoryFromCreateDTO();
            HistoryModel.UserId = AppUser;
                

            // Call repository to approve or decline the document and create a history record
            var result = await _approval.ApproveOrDeclineAsync(id, isApproved, HistoryModel.UserId);

            if (result == null && !isApproved)
            {
                return Ok(new { Message = "Declined" });
            }

            if (result == null)
            {
                return NotFound(new { Message = $"Approval with ID {id} not found." });
            }

            return Ok(new { Message = isApproved ? "Approved" : "Declined", OfficeId = result.OfficeId });
        }


    }
}