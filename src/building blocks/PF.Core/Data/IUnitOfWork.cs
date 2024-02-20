namespace PF.Core.Data;

public interface IUnitOfWork
{
    Task<bool> Commit();
}
