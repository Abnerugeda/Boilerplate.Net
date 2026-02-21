using Domain.Entities;

namespace Domain.Interfaces;

public interface IUnitOfWork
{
    Task Commmit(CancellationToken cancellationToken);
}