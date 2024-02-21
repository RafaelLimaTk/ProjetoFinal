using AutoMapper;
using PF.Estabelecimento.API.Application.DTOs;
using PF.Estabelecimento.API.Models;

namespace PF.Estabelecimento.API.Application.Mappings;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile()
    {
        CreateMap<Establishment, EstablishmentDto>();
    }
}
