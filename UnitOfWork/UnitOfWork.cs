using Database;
using Entities;
using Repositories.Abstract;
using UnitOfWOrk.Abstract;

namespace UnitOfWOrk
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        public IRepository<Customer> Customers { get; }
        public IRepository<Hotel> Hotels { get; }
        public IRepository<Room> Rooms { get; }

        public UnitOfWork(DatabaseContext context, IRepository<Customer> customers,
            IRepository<Hotel> hotels, IRepository<Room> rooms) =>
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
