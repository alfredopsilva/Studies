using System.Drawing;
using ASPNet.API.Models.Domain;
using ASPNet.API.Models.DTOs;
using AutoMapper;
using Region = ASPNet.API.Models.Domain.Region;

namespace ASPNet.API.Mappings;

public class Profiles : Profile
{
    public Profiles()
    {
        CreateMap<Region, RegionDTO>().ReverseMap();
        CreateMap<AddRegionRequestDto, Region>().ReverseMap();
        CreateMap<UpdateRegionRequestDto, Region>().ReverseMap();
        CreateMap<addWalkRequestDTO, Walk>().ReverseMap();
        CreateMap<Walk, WalkDTO>().ReverseMap();
        CreateMap<Difficulty, DifficultyDTO>().ReverseMap();
        CreateMap<UpdateWalkRequestDTO, Walk>().ReverseMap();
    }
}

