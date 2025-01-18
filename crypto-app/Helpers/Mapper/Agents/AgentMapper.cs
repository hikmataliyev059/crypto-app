using AutoMapper;
using crypto_app.Helpers.DTOs.Agents;
using crypto_app.Models;

namespace crypto_app.Helpers.Mapper.Agents;

public class AgentMapper : Profile
{
    public AgentMapper()
    {
        CreateMap<CreateAgentDto, Agent>().ReverseMap();
        CreateMap<UpdateAgentDto, Agent>().ReverseMap();
    }
}
