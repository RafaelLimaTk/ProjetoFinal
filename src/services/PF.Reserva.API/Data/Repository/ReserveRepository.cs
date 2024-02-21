using Microsoft.EntityFrameworkCore;
using PF.Core.Data;
using PF.Reserva.API.Models;

namespace PF.Reserva.API.Data.Repository;

public class ReserveRepository : IReserveRepository
{
    private readonly ReserveContext _context;
    public ReserveRepository(ReserveContext context)
    {
        _context = context;
    }

    public IUnitOfWork UnitOfWork => _context;

    public async Task<IEnumerable<Reserver>> GetAll()
    {
        return await _context.Reserves.AsNoTracking().ToListAsync();
    }

    public async Task<Reserver> GetById(Guid id)
    {
        return await _context.Reserves.FindAsync(id);
    }

    public void Add(Reserver reserve)
    {
        _context.Reserves.Add(reserve);
    }
    public void Update(Reserver reserve)
    {
        _context.Reserves.Update(reserve);
    }

    public void Delete(Reserver reserve)
    {
        _context.Reserves.Remove(reserve);
    }

    public void Dispose()
    {
        _context?.Dispose();
    }
}
