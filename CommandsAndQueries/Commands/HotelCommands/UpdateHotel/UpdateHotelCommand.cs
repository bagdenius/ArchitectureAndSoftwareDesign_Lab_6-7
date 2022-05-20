using MediatR;

namespace CommandsAndQueries.Commands.HotelCommands.UpdateHotel
{
    public class UpdateHotelCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Stars { get; set; }
        public int NumberOfFloors { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
