using Autofac;
using UnitOfWOrk;
using UnitOfWOrk.Abstract;

namespace ModulesDAL
{
    public class UnitOfWorkModule : Module
    {
        protected override void Load(ContainerBuilder builder) =>
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().SingleInstance();
    }
}
