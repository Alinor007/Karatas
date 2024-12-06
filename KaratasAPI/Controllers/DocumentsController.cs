using AutoMapper;
using KaratasAPI.Data;
using KaratasAPI.DTOs;
using KaratasAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KaratasAPI.Controllers
{
    public class DocumentsController : Controller
    {
        public readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DocumentsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult<DocumentReadDto>> CreateDocument(DocumentCreateDto documentDto)
        {
            var document = _mapper.Map<Document>(documentDto);
            document.Status = "Pending";
            document.CurrentApprover = "Chairperson";
            document.CreatedAt = DateTime.Now;

            _context.Documents.Add(document);
            await _context.SaveChangesAsync();

            var documentReadDto = _mapper.Map<DocumentReadDto>(document);
            return CreatedAtAction(nameof(GetDocument), new { id = document.Id }, documentReadDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DocumentReadDto>> GetDocument(int id)
        {
            var document = await _context.Documents.FindAsync(id);
            if (document == null) return NotFound();

            var documentReadDto = _mapper.Map<DocumentReadDto>(document);
            return Ok(documentReadDto);
        }

        [HttpPost("{id}/forward")]
        public async Task<IActionResult> ForwardDocument(int id)
        {
            var document = await _context.Documents.FindAsync(id);
            if (document == null) return NotFound();

            switch (document.CurrentApprover)
            {
                case "Chairperson":
                    document.CurrentApprover = "Dean";
                    break;
                case "Dean":
                    document.CurrentApprover = "President";
                    break;
                case "President":
                    return BadRequest("Document is already with the President and cannot be forwarded further.");
                default:
                    return BadRequest("Invalid workflow state.");
            }

            document.UpdatedAt = DateTime.Now;
            _context.Entry(document).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("{id}/decline")]
        public async Task<IActionResult> DeclineDocument(int id)
        {
            var document = await _context.Documents.FindAsync(id);
            if (document == null) return NotFound();

            switch (document.CurrentApprover)
            {
                case "Chairperson":
                    document.Status = "Declined";
                    document.Remark = "Declined by Chairperson";
                    document.CurrentApprover = "Proponents";
                    break;
                case "Dean":
                    document.Status = "Declined";
                    document.Remark = "Declined by Dean";
                    document.CurrentApprover = "Chairperson";
                    break;
                case "President":
                    document.Status = "Declined";
                    document.Remark = "Declined by President";
                    document.CurrentApprover = "Dean";
                    break;
                default:
                    return BadRequest("Invalid workflow state.");
            }

            document.UpdatedAt = DateTime.Now;
            _context.Entry(document).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("{id}/approve")]
        public async Task<IActionResult> ApproveDocument(int id)
        {
            var document = await _context.Documents.FindAsync(id);
            if (document == null) return NotFound();

            if (document.CurrentApprover != "President")
            {
                return BadRequest("Only the President can fully approve the document.");
            }

            document.Status = "Approved";
            document.Remark = "Fully Approved";
            document.CurrentApprover = "Proponents";
            document.UpdatedAt = DateTime.Now;

            _context.Entry(document).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
