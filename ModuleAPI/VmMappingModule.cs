using Autofac;
using AutoMapper;
using EntityViewModelMappers;

namespace ModulesBLL
{
    public class VmMappingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<RoomVMMapper>();
                cfg.AddProfile<HotelVMMapper>();
                cfg.AddProfile<CustomerVMMapper>();
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