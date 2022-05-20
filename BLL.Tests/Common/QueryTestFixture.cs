using AutoMapper;
using Database;
using Entities;
using EntityViewModelMappers;
using Repositories;
using Repositories.Abstract;
using System;
using System.Collections.Generic;
using UI.WebAPI.ModelCommandMappers;
using UnitOfWOrk;
using UnitOfWOrk.Abstract;
using Xunit;

namespace BLL.Tests.Common
{
    public class QueryTestFixture : IDisposable
    {
        private readonly DatabaseContext Context;
        private readonly IRepository<Hotel> hotelRepository;
        private readonly IRepository<Room> roomRepository;
        private readonly IRepository<Customer> customerRepository;
        public IUnitOfWork unitOfWork;
        public IMapper Mapper;

        public QueryTestFixture()
        {
            Context = ContextFactory.Create();
            hotelRepository = new Repository<Hotel>(Context);
            roomRepository = new Repository<Room>(Context);
            customerRepository = new Repository<Customer>(Context);
            unitOfWork = new UnitOfWork(Context, customerRepository, hotelRepository, roomRepository);
            var configurationProvider = new MapperConfiguration(cfg =>
            cfg.AddProfiles(new List<Profile>()
            {
                new CustomerModelMapper(), new HotelModelMapper(), new RoomModelMapper(),
                new CustomerVMMapper(), new HotelVMMapper(), new RoomVMMapper()
            }));
            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose() => ContextFactory.Destroy(Context);

    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
