using AutoMapper;
using CommandsAndQueries.Commands.HotelCommands.AddHotel;
using CommandsAndQueries.Commands.HotelCommands.UpdateHotel;
using UI.WebAPI.Models.Hotel;

namespace UI.WebAPI.ModelCommandMappers
{
    public class HotelModelMapper : Profile
    {
        public HotelModelMapper()
        {
            CreateMap<AddHotelModel, AddHotelCommand>();
            CreateMap<UpdateHotelModel, UpdateHotelCommand>();
        }
    }
}
