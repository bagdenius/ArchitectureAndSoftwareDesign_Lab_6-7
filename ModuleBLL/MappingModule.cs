using Autofac;
using AutoMapper;
using Mappers;

namespace ModulesBLL
{
    public class MappingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<RoomMapper>();
                cfg.AddProfile<HotelMapper>();
                cfg.AddProfile<CustomerMapper>();
            }
            )).AsSelf().SingleInstance();

            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();
        }
    }
}