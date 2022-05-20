using Autofac;
using Entities;
using Repositories;
using Repositories.Abstract;

namespace Database
{
    public class RepositoriesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Repository<Customer>>().As<IRepository<Customer>>()/*.SingleInstance()*/;
            builder.RegisterType<Repository<Hotel>>().As<IRepository<Hotel>>()/*.SingleInstance()*/;
            builder.RegisterType<Repository<Room>>().As<IRepository<Room>>()/*.SingleInstance()*/;
        }
    }
}
