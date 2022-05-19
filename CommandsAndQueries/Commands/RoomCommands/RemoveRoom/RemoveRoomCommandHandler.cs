using AutoMapper;
using CommandsAndQueries.Exceptions;
using Domain;
using MediatR;
using Services.Abstract;

namespace CommandsAndQueries.Commands.RoomCommands.RemoveRoom
{
    public class RemoveRoomCommandHandler : IRequestHandler<RemoveRoomCommand>
    {
        private readonly IService<Room> _service;
        private readonly IMapper _mapper;
        public RemoveRoomCommandHandler(IService<Room> service, IMapper mapper) =>
            (_service, _mapper) = (service, mapper);

        public async Task<Unit> Handle(RemoveRoomCommand request, CancellationToken cancellationToken)
        {
            var room = await _service.GetAsync(request.Id, cancellationToken);
            if (room == null || room.Id != request.Id)
                throw new NotFoundException(nameof(Room), request.Id);
            _service.Remove(room.Id);
            await _service.SaveAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
