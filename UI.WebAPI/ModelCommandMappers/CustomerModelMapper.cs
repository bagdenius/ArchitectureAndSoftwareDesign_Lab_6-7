using AutoMapper;
using CommandsAndQueries.ResumeCommands.CreateResume;
using CommandsAndQueries.ResumeCommands.UpdateResume;
using UI.WebAPI.Models.Customer;

namespace UI.WebAPI.ModelCommandMappers
{
    public class CustomerModelMapper : Profile
    {
        public CustomerModelMapper()
        {
            CreateMap<AddCustomerModel, AddCustomerCommand>();
            CreateMap<UpdateCustomerModel, UpdateCustomerCommand>();
        }
    }
}
