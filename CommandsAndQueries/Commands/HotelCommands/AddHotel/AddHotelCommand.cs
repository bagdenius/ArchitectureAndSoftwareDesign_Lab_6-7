using MediatR;

namespace CommandsAndQueries.Commands.HotelCommands.AddHotel
{
    public class AddHotelCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Stars { get; set; }
        public int NumberOfFloors { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
