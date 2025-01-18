using AutoMapper;
using crypto_app.Helpers.DTOs.Positions;
using crypto_app.Models;

namespace crypto_app.Helpers.Mapper.Positions;

public class PositionMapper : Profile
{
    public PositionMapper()
    {
        CreateMap<CreatePositionDto, Position>().ReverseMap();
        CreateMap<UpdatePositionDto, Position>().ReverseMap();
    }
}
