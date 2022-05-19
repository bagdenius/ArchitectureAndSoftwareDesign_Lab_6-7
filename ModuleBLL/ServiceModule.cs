using Autofac;
using DAL_Modules;
using Domains;
using Services;
using Services.Abstract;

namespace BLL_Modules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HotelsService>().As<IService<Hotel>>().SingleInstance();
            builder.RegisterType<RoomsService>().As<IService<Room>>().SingleInstance();
            builder.RegisterType<CustomersService>().As<IService<Customer>>().SingleInstance();
            builder.RegisterModule<UoWModule>();
        }
    }
}
