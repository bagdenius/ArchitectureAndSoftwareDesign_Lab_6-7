using Database;
using Entities;
using Repositories;
using Repositories.Abstract;
using System;
using UnitOfWOrk;
using UnitOfWOrk.Abstract;

namespace BLL.Tests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly DatabaseContext Context;
        protected readonly IRepository<Hotel> hotelRepository;
        protected readonly IRepository<Room> roomRepository;
        protected readonly IRepository<Customer> customerRepository;
        protected readonly IUnitOfWork unitOfWork;

        public TestCommandBase()
        {
            Context = ContextFactory.Create();
            hotelRepository = new Repository<Hotel>(Context);
            roomRepository = new Repository<Room>(Context);
            customerRepository = new Repository<Customer>(Context);
            unitOfWork = new UnitOfWork(Context, customerRepository, hotelRepository, roomRepository);
        }

        public void Dispose() => ContextFactory.Destroy(Context);
    }
}
