using Microsoft.EntityFrameworkCore;
using PF.Core.Data;
using PF.Estabelecimento.API.Models;

namespace PF.Estabelecimento.API.Data.Repository;

public class EstablishmentRepository : IEstablishmentRepository
{
    private readonly EstablishmentContext _context;
    public EstablishmentRepository(EstablishmentContext context)
    {
        _context = context;
    }

    public IUnitOfWork UnitOfWork => _context;

    public async Task<IEnumerable<Establishment>> GetAll()
    {
        return await _context.Establishments.AsNoTracking().ToListAsync();
    }

    public async Task<Establishment> GetById(Guid id)
    {
        return await _context.Establishments.FindAsync(id);
    }

    public void Add(Establishment establishment)
    {
        _context.Establishments.Add(establishment);
    }

    public void Update(Establishment establishment)
    {
        _context.Establishments.Update(establishment);
    }

    public void Dispose()
    {
        _context?.Dispose();
    }
}
