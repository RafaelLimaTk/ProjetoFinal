using PF.Core.Data;

namespace PF.Estabelecimento.API.Models;

public interface IEstablishmentRepository : IRepository<Establishment>
{
    Task<IEnumerable<Establishment>> GetAll();
    Task<Establishment> GetById(Guid id);

    void Add(Establishment establishment);
    void Update(Establishment establishment);
}
