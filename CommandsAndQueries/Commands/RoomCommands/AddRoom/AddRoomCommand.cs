using MediatR;

namespace CommandsAndQueries.Commands.RoomCommands.AddRoom
{
    public class AddRoomCommand : IRequest<Guid>
    {
        public Guid HotelId { get; set; }
        public string Number { get; set; }
        public int? Floor { get; set; }
        public double Cost { get; set; }
        public double Area { get; set; }
        public string RoomCategory { get; set; }
        public string ServicesAndAmenities { get; set; }
        public string WindowsView { get; set; }
    }
}
