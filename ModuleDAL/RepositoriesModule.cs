using Autofac;
using Entities;
using Repositories;
using Repositories.Abstract;

namespace ModulesDAL
{
    public class RepositoriesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Repository<CustomerEntity>>().As<IRepository<CustomerEntity>>()/*.SingleInstance()*/;
            builder.RegisterType<Repository<HotelEntity>>().As<IRepository<HotelEntity>>()/*.SingleInstance()*/;
            builder.RegisterType<Repository<RoomEntity>>().As<IRepository<RoomEntity>>()/*.SingleInstance()*/;
        }
    }
}
