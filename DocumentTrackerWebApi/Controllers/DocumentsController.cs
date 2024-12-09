using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DocumentTracker.Models;
using DocumentTrackerWebApi.Data;
using DocumentTrackerWebApi.DTOs;
using DocumentTrackerWebApi.Extension;
using DocumentTrackerWebApi.Interfaces;
using DocumentTrackerWebApi.Mappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DocumentTrackerWebApi.Controllers
{
    [Route("api/Documents")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentRepository _documentRepo;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        private static string GenerateTrackingNumber()
        {
            DateTime now = DateTime.Now;
            string year = now.ToString("yy");
            string month = now.ToString("MM");
            string day = now.ToString("dd");
            string militaryTime = now.ToString("HH") + now.ToString("mm") + now.ToString("ss");
            string milliseconds = now.ToString("ffff");
            return $"{year}{month}{day}{militaryTime}{milliseconds}";
        }

        public DocumentsController(
            IDocumentRepository documentRepo,
            ApplicationDbContext context,
            UserManager<User> userManager,
            IWebHostEnvironment webHostEnvironment)  // Inject IWebHostEnvironment
        {
            _documentRepo = documentRepo;
            _context = context;
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;  // Initialize IWebHostEnvironment
        }

        // GET: api/documents
        [HttpGet]
        public async Task<ActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            if (page <= 0 || pageSize <= 0)
            {
                return BadRequest(new { Message = "Page and pageSize must be greater than zero." });
            }

            var (documents, totalDocuments) = await _documentRepo.GetPaginatedAsync(page, pageSize);

            var documentsDto = documents.Select(d => d.ToDocumentDto());

            var response = new
            {
                Data = documentsDto,
                TotalCount = totalDocuments,
                CurrentPage = page,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(totalDocuments / (double)pageSize)
            };

            return Ok(response);
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
        [HttpPost("Add")]
        public async Task<ActionResult<DocumentDTO>> CreateDocument([FromBody] CreateDocumentDTO createDocumentDto)
        {
            

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(new { Message = "Invalid or missing user credentials." });
            }
          

            var documentModel = createDocumentDto.ToDocumentFromCreateDTO();
            //if (createDocumentDto.File != null)
            //{
            //    var fileName = Path.GetFileNameWithoutExtension(createDocumentDto.File.FileName);
            //    var extension = Path.GetExtension(createDocumentDto.File.FileName);
            //    var newFileName = $"{fileName}_{Guid.NewGuid()}{extension}";
            //    var path = Path.Combine("Uploads", newFileName); // Define your upload directory

            //    // Save file to the path
            //    using (var stream = new FileStream(path, FileMode.Create))
            //    {
            //        await createDocumentDto.File.CopyToAsync(stream);
            //    }

            //    documentModel.FilePath = path;
            //    documentModel.FileName = createDocumentDto.File.FileName;
            //    documentModel.FileType = createDocumentDto.File.ContentType;
            //}

              documentModel.OwnerId = userId;
            // Add and save new document
            await _documentRepo.AddAsync(documentModel);

            // Create initial DocumentApproval record
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

            return CreatedAtAction(nameof(GetById), new { id = documentModel.Id }, documentModel.ToDocumentDto());
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
