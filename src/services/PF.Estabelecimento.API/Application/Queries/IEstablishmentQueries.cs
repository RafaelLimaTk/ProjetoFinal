using AutoMapper;
using PF.Estabelecimento.API.Application.DTOs;
using PF.Estabelecimento.API.Models;

namespace PF.Estabelecimento.API.Application.Queries;

public interface IEstablishmentQueries
{
    Task<IEnumerable<EstablishmentDto>> GetAll();
    Task<EstablishmentDto> GetById(Guid id);
}

public class EstablishmentQueries : IEstablishmentQueries
{
    private readonly IMapper _mapper;
    private readonly IEstablishmentRepository _establishmentRepository;
    public EstablishmentQueries(IMapper mapper, IEstablishmentRepository establishmentRepository)
    {
        _mapper = mapper;
        _establishmentRepository = establishmentRepository;
    }

    public async Task<IEnumerable<EstablishmentDto>> GetAll()
    {
        var establishment = await _establishmentRepository.GetAll();
        return _mapper.Map<IEnumerable<EstablishmentDto>>(establishment);
    }

    public async Task<EstablishmentDto> GetById(Guid id)
    {
        var establishment = await _establishmentRepository.GetById(id);
        return _mapper.Map<EstablishmentDto>(establishment);
    }
}