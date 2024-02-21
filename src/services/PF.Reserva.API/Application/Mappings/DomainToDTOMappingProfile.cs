using AutoMapper;
using PF.Reserva.API.Application.DTOs;
using PF.Reserva.API.Models;

namespace PF.Reserva.API.Application.Mappings;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile()
    {
        CreateMap<Reserver, ReserveDto>();
    }
}
