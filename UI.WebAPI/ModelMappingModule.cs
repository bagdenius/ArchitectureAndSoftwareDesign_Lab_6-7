using Autofac;
using AutoMapper;
using EntityViewModelMappers;
using UI.WebAPI.ModelCommandMappers;

namespace UI.WebAPI
{
    public class ModelMappingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<RoomVMMapper>();
                cfg.AddProfile<HotelVMMapper>();
                cfg.AddProfile<CustomerVMMapper>();
                cfg.AddProfile<RoomModelMapper>();
                cfg.AddProfile<HotelModelMapper>();
                cfg.AddProfile<CustomerModelMapper>();
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
