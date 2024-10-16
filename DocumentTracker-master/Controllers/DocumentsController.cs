using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using DocumentTracker.Models;
using DocumentTrackerWebApi.Data;
using DocumentTrackerWebApi.DTOs;
using DocumentTrackerWebApi.Extension;
using DocumentTrackerWebApi.Helpers;
using DocumentTrackerWebApi.Interfaces;
using DocumentTrackerWebApi.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DocumentTrackerWebApi.Controllers
{
    [Route("api/Document")]
    [ApiController]


    public class DocumentsController:ControllerBase
    {
        private readonly IDocumentRepository _documentRepo;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;


        public DocumentsController(IDocumentRepository documentRepo, ApplicationDbContext context,UserManager<User> userManager)
        {
            _documentRepo = documentRepo;
            _context = context;
            _userManager = userManager;
        }


        // GET: api/documents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocumentDTO>>> GetAll()
        {
            var documents = await _documentRepo.GetAllAsync();
            var documentsDto = documents.Select(d => d.ToDocumentDto());
            return Ok(documentsDto);
        }

        // GET: api/documents/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<DocumentDTO>> GetById(int id)
        {
            var document = await _documentRepo.GetByIdAsync(id);
            if (document == null)
            {
                return NotFound(new { Message = $"Document with ID {id} not found." });
            }
            return Ok(document.ToDocumentDto());
        }

        // POST: api/documents
        [HttpPost]
        public async Task<ActionResult<DocumentDTO>> CreateDocument([FromBody] CreateDocumentDTO createDocumentDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var username = User.GetUsername();
            var AppUser = await _userManager.FindByEmailAsync(username);

            var documentModel = createDocumentDto.ToDocumentFromCreateDTO();

            documentModel.UserId = AppUser.Id;
            await _documentRepo.AddAsync(documentModel); 
            // Create DocumentApproval
            var documentApproval = new DocumentApproval
            {
                DocumentId = documentModel.Id,
                OfficeId = 1,
                Comments = "Forwarded",
                Remarks = "In-Reviewed",
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow
            };
            await _context.DocumentApprovals.AddAsync(documentApproval);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = documentModel.Id }, documentModel);

        }

        // PUT: api/documents/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateDocument(int id, [FromBody] UpdateDocumentDTO updateDocumentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedDocument = await _documentRepo.UpdateAsync(id, updateDocumentDto);
            if (updatedDocument == null)
            {
                return NotFound(new { Message = $"Document with ID {id} not found or could not be updated." });
            }

            return Ok(updatedDocument.ToDocumentDto());
        }

        // DELETE: api/documents/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteDocument(int id)
        {
            var deletedDocument = await _documentRepo.DeleteAsync(id);
            if (deletedDocument == null)
            {
                return NotFound(new { Message = $"Document with ID {id} not found." });
            }

            return NoContent(); // HTTP 204
        }
        
    }
}