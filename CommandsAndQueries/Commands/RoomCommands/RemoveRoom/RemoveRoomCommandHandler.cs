using CommandsAndQueries.Exceptions;
using Entities;
using MediatR;
using UnitOfWOrk.Abstract;

namespace CommandsAndQueries.Commands.RoomCommands.RemoveRoom
{
    public class RemoveRoomCommandHandler : IRequestHandler<RemoveRoomCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public RemoveRoomCommandHandler(IUnitOfWork unitOfWork) =>
            _unitOfWork = unitOfWork;

        public async Task<Unit> Handle(RemoveRoomCommand request, CancellationToken cancellationToken)
        {
            var room = await _unitOfWork.Rooms.GetAsync(request.Id, cancellationToken);
            if (room == null)
                throw new NotFoundException(nameof(Room), request.Id);
            _unitOfWork.Rooms.Remove(room);
            await _unitOfWork.SaveAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
