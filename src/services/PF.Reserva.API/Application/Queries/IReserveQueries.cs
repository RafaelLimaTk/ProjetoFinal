using AutoMapper;
using PF.Reserva.API.Application.DTOs;
using PF.Reserva.API.Models;

namespace PF.Reserva.API.Application.Queries;

public interface IReserveQueries
{
    Task<IEnumerable<ReserveDto>> GetAll();
}

public class ReservaQueries : IReserveQueries
{
    private readonly IMapper _mapper;
    private readonly IReserveRepository _reserveRepository;
    public ReservaQueries(IReserveRepository reserveRepository, IMapper mapper)
    {
        _reserveRepository = reserveRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ReserveDto>> GetAll()
    {
        var reserves = await _reserveRepository.GetAll();
        return _mapper.Map<IEnumerable<ReserveDto>>(reserves);
    }
}