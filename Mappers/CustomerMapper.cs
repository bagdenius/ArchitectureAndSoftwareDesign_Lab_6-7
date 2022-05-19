using AutoMapper;
using Domain;
using Entities;
using ViewModels;

namespace Mappers
{
    public class CustomerMapper : Profile
    {
        public CustomerMapper()
        {
            CreateMap<Customer, CustomerEntity>().ReverseMap();
            CreateMap<Customer, CustomerVM>().ReverseMap();
        }
    }
}
