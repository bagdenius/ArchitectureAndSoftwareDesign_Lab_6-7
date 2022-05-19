using Entities;
using Repositories.Abstract;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace UnitOfWOrk.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<CustomerEntity> Customers { get; }
        IRepository<HotelEntity> Hotels { get; }
        IRepository<RoomEntity> Rooms { get; }
        void Save();
        Task SaveAsync(CancellationToken cancellationToken);
    }
}
