using AutoMapper;
using Entities;
using ViewModels;

namespace EntityViewModelMappers
{
    public class CustomerMapper : Profile
    {
        public CustomerMapper()
        {
            CreateMap<Customer, CustomerVM>().ReverseMap();
        }
    }
}
