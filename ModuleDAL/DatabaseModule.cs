using Autofac;
using Database;

namespace ModulesDAL
{
    public class DatabaseModule : Module
    {
        protected override void Load(ContainerBuilder builder) =>
            builder.RegisterType<DatabaseContext>().AsSelf().SingleInstance();
    }
}
