using Autofac;
using Domain;
using ModulesDAL;
using Services;
using Services.Abstract;

namespace ModulesBLL
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HotelService>().As<IService<Hotel>>().SingleInstance();
            builder.RegisterType<RoomService>().As<IService<Room>>().SingleInstance();
            builder.RegisterType<CustomerService>().As<IService<Customer>>().SingleInstance();
            builder.RegisterModule<UnitOfWorkModule>();
        }
    }
}
