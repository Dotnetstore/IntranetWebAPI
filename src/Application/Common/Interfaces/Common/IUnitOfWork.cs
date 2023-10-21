using Domain.Common;

namespace Application.Common.Interfaces.Common;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<T> Repository<T>() where T : BaseAuditableEntity;

    Task<int> SaveAsync(CancellationToken cancellationToken);

    void Rollback();
}