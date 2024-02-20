using PF.Core.Data;

namespace PF.Reserva.API.Models;

public interface IReserveRepository : IRepository<Reserve>
{
    Task<IEnumerable<Reserve>> GetAll();
    Task<Reserve> GetById(Guid id);
    void Add(Reserve reserve);
    void Update(Reserve reserve);
    void Delete(Reserve reserve);
}
