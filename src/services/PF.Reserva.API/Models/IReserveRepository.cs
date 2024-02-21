using PF.Core.Data;

namespace PF.Reserva.API.Models;

public interface IReserveRepository : IRepository<Reserver>
{
    Task<IEnumerable<Reserver>> GetAll();
    Task<Reserver> GetById(Guid id);
    void Add(Reserver reserve);
    void Update(Reserver reserve);
    void Delete(Reserver reserve);
}
