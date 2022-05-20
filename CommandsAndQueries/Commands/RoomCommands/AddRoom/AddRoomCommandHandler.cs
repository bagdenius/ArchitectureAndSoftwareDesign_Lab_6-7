using Entities;
using MediatR;
using UnitOfWOrk.Abstract;
using ViewModels.enums;

namespace CommandsAndQueries.Commands.RoomCommands.AddRoom
{
    public class AddRoomCommandHandler : IRequestHandler<AddRoomCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddRoomCommandHandler(IUnitOfWork unitOfWork) =>
            _unitOfWork = unitOfWork;

        public async Task<Guid> Handle(AddRoomCommand request, CancellationToken cancellationToken)
        {
            var room = new Room
            {
                Id = Guid.NewGuid(),
                HotelId = request.HotelId,
                Number = request.Number,
                Floor = (int)request.Floor,
                Cost = request.Cost,
                Area = request.Area,
                RoomCategory = request.RoomCategory,
                ServicesAndAmenities = request.ServicesAndAmenities,
                WindowsView = request.WindowsView,
                BookingState = BookingState.Вільний.ToString()
            };
            await _unitOfWork.Rooms.AddAsync(room, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);
            return room.Id;
        }
    }
}
