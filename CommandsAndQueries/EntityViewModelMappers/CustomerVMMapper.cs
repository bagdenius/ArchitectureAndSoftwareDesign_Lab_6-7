using AutoMapper;
using Entities;
using ViewModels;

namespace EntityViewModelMappers
{
    public class CustomerVMMapper : Profile
    {
        public CustomerVMMapper()
        {
            CreateMap<Customer, CustomerVM>().ReverseMap();
        }
    }
}
