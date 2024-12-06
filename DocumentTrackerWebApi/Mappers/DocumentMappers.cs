using System;
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
                UserId = documentModel.UserId,
                CreatedBy = documentModel.User != null ? documentModel.User.Email : string.Empty,  // Handles null case for User
                Title = documentModel.Title,
                Status = documentModel.Status,
                Created = documentModel.DateCreated,
                Updated = documentModel.DateUpdated
            };
        }

        // Maps CreateDocumentDTO to Document model
        public static Document ToDocumentFromCreateDTO(this CreateDocumentDTO documentDTO)
        {
            return new Document
            {
                Title = documentDTO.Title,
                Owner = documentDTO.Owner ?? string.Empty,
                Status = DocumentStatus.Pending, // Assuming default status as Pending
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            };
        }

        // Updates Document model from UpdateDocumentDTO
        public static void UpdateDocumentFromUpdateDTO(this UpdateDocumentDTO updateDocumentDTO, Document documentModel)
        {
            if (!string.IsNullOrEmpty(updateDocumentDTO.Title))
            {
                documentModel.Title = updateDocumentDTO.Title;
            }

            if (updateDocumentDTO.Status.HasValue)
            {
                documentModel.Status = updateDocumentDTO.Status.Value;
            }

            documentModel.DateUpdated = DateTime.UtcNow; // Update timestamp
        }
    }
}
