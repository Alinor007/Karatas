using KaratasAPI.DTOs;
using AutoMapper;
using static System.Runtime.InteropServices.JavaScript.JSType;
using KaratasAPI.Models;

namespace KaratasAPI.Helper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            // Domain to DTO
            CreateMap<Document, DocumentReadDto>();
            // DTO to Domain
            CreateMap<DocumentCreateDto, Document>();
            // User mappings
            // Mapping for users
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>()
                .ForMember(dest => dest.Password, opt => opt.Ignore()); // Prevent overwriting password unless explicitly set
        }
    }
    }

