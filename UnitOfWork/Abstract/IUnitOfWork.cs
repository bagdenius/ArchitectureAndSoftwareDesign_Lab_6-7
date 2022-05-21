using Entities;
using Repositories.Abstract;

namespace UnitOfWOrk.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Customer> Customers { get; }
        IRepository<Hotel> Hotels { get; }
        IRepository<Room> Rooms { get; }
        void Save();
        Task SaveAsync(CancellationToken cancellationToken);
    }
}
