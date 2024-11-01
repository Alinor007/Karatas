using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentTracker.Models;
using DocumentTrackerWebApi.DTOs;

namespace DocumentTrackerWebApi.Mappers
{
    public static class DocumentMappers
    {
           // Maps Document model to DocumentDTO
        public static DocumentDTO ToDocumentDto(this Document documentModel)
        {
            return new DocumentDTO
            {
                Id = documentModel.Id,
                CreatedBy = documentModel.User != null ? documentModel.User.Email : string.Empty,  // Handle null case
                Name = documentModel.Name,
                Status = documentModel.status,
                Created = documentModel.Created,
                Updated = documentModel.Updated
            };
        }

        // Maps CreateDocumentDTO to Document model
        public static Document ToDocumentFromCreateDTO(this CreateDocumentDTO documentDTO)
        {
            return new Document
            {

                Name = documentDTO.Name,
                status = documentDTO.Status,
                Created = DateTime.UtcNow, // Set by server
                Updated = DateTime.UtcNow  // Initialize as Created time
            };
        }

         public static void UpdateDocumentFromUpdateDTO(this UpdateDocumentDTO updateDocumentDTO, Document documentModel)
        {
            if (!string.IsNullOrEmpty(updateDocumentDTO.Name))
            {
                documentModel.Name = updateDocumentDTO.Name;
            }

            if (updateDocumentDTO.Status.HasValue)
            {
                documentModel.status = updateDocumentDTO.Status.Value;
            }

            documentModel.Updated = DateTime.UtcNow; // Update timestamp
        }
        
    }
}