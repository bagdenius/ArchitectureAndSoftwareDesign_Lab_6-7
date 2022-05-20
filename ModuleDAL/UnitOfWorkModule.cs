using Autofac;
using UnitOfWOrk;
using UnitOfWOrk.Abstract;

namespace Database
{
    public class UnitOfWorkModule : Module
    {
        protected override void Load(ContainerBuilder builder) =>
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().SingleInstance();
    }
}
