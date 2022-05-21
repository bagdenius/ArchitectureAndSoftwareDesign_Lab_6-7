using Autofac;

namespace Database
{
    public class DatabaseModule : Module
    {
        protected override void Load(ContainerBuilder builder) =>
            builder.RegisterType<DatabaseContext>().
            WithParameter("options", DbContextOptionsFactory.Get()).AsSelf().SingleInstance();
    }
}
