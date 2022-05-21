using Autofac;
using CommandsAndQueries.ResumeCommands.CreateResume;
using CommandsAndQueries.ResumeQueries.GetCustomer;
using MediatR.Extensions.Autofac.DependencyInjection;
using System.Reflection;

namespace ModulesBLL
{
    public class CommandsAndQueriesModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterMediatR(typeof(AddCustomerCommandHandler).GetTypeInfo().Assembly);
            builder.RegisterMediatR(typeof(GetCustomerQueryHandler).GetTypeInfo().Assembly);
        }
    }
}
