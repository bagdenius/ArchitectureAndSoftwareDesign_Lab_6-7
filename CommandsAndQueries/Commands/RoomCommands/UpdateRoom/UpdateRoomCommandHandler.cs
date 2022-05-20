using CommandsAndQueries.Exceptions;
using Entities;
using MediatR;
using UnitOfWOrk.Abstract;

namespace CommandsAndQueries.Commands.RoomCommands.UpdateRoom
{
    public class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateRoomCommandHandler(IUnitOfWork unitOfWork) =>
            _unitOfWork = unitOfWork;

        public async Task<Unit> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
        {
            var room = await _unitOfWork.Rooms.GetAsync(request.Id, cancellationToken);
            if (room == null)
                throw new NotFoundException(nameof(Room), request.Id);
            room.Id = request.Id;
            room.Number = request.Number;
            room.Floor = (int)request.Floor;
            room.Cost = request.Cost;
            room.Area = request.Area;
            room.RoomCategory = request.RoomCategory;
            room.ServicesAndAmenities = request.ServicesAndAmenities;
            room.WindowsView = request.WindowsView;
            await _unitOfWork.SaveAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
