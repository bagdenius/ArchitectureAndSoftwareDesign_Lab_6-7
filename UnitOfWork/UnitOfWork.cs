using Database;
using Entities;
using Repositories.Abstract;
using System;
using System.Threading;
using System.Threading.Tasks;
using UnitOfWOrk.Abstract;

namespace UnitOfWOrk
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        public IRepository<CustomerEntity> Customers { get; }
        public IRepository<HotelEntity> Hotels { get; }
        public IRepository<RoomEntity> Rooms { get; }

        public UnitOfWork(DatabaseContext context, IRepository<CustomerEntity> customers,
            IRepository<HotelEntity> hotels, IRepository<RoomEntity> rooms) =>
            (_context, Customers, Hotels, Rooms) = (context, customers, hotels, rooms);

        public void Save() => _context.SaveChanges();
        public async Task SaveAsync(CancellationToken cancellationToken) =>
            await _context.SaveChangesAsync(cancellationToken);

        #region Disposing

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                    _context.Dispose();
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
