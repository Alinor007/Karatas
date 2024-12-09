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
                Title = documentModel.Title,
                TrackingNumber =documentModel.TrackingNumber,
                Status = documentModel.Status,
                Type = documentModel.Type,
                OwnerId = documentModel.owner.UserName,
                DateCreated = documentModel.DateCreated,
                DateUpdated = documentModel.DateUpdated

            };
        }

        // Maps CreateDocumentDTO to Document model
        public static Document ToDocumentFromCreateDTO(this CreateDocumentDTO documentDTO)
        {
            return new Document
            {
                Title = documentDTO.Title,
                Status = documentDTO.Status,
                Type = documentDTO.Type,
                OwnerId = documentDTO.OwnerId
            };
        }

        // Updates Document model from UpdateDocumentDTO
        public static void UpdateDocumentFromUpdateDTO(this UpdateDocumentDTO updateDocumentDTO, Document documentModel)
        {
           
        }
    }
}
