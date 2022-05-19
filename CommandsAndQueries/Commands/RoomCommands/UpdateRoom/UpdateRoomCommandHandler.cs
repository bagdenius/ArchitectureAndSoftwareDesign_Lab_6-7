using AutoMapper;
using CommandsAndQueries.Exceptions;
using Domain;
using MediatR;
using Services.Abstract;
using ViewModels;

namespace CommandsAndQueries.Commands.RoomCommands.UpdateRoom
{
    public class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand>
    {
        private readonly IService<Room> _service;
        private readonly IMapper _mapper;
        public UpdateRoomCommandHandler(IService<Room> service, IMapper mapper) =>
            (_service, _mapper) = (service, mapper);

        public async Task<Unit> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
        {
            var room = _mapper.Map<RoomVM>(await _service.GetAsync(request.Id, cancellationToken));
            if (room == null || room.Id != request.Id)
                throw new NotFoundException(nameof(Customer), request.Id);
            room.Id = request.Id;
            room.HotelId = request.HotelId;
            room.Number = request.Number;
            room.Floor = request.Floor;
            room.Cost = request.Cost;
            room.Area = request.Area;
            room.RoomCategory = request.RoomCategory;
            room.ServicesAndAmenities = request.ServicesAndAmenities;
            room.WindowsView = request.WindowsView;
            room.BookingState = request.BookingState;
            room.BookingStartDate = request.BookingStartDate;
            room.BookingEndDate = request.BookingEndDate;
            await _service.SaveAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
