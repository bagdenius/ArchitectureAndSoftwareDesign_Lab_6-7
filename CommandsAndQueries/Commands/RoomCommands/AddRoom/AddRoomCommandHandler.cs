using AutoMapper;
using Domain;
using MediatR;
using Services.Abstract;
using ViewModels;
using ViewModels.enums;

namespace CommandsAndQueries.Commands.RoomCommands.AddRoom
{
    public class AddRoomCommandHandler : IRequestHandler<AddRoomCommand, Guid>
    {
        private readonly IService<Room> _service;
        private readonly IMapper _mapper;
        public AddRoomCommandHandler(IService<Room> service, IMapper mapper) =>
            (_service, _mapper) = (service, mapper);

        public async Task<Guid> Handle(AddRoomCommand request, CancellationToken cancellationToken)
        {
            var room = new RoomVM
            {
                Id = Guid.NewGuid(),
                HotelId = request.HotelId,
                Number = request.Number,
                Floor = request.Floor,
                Cost = request.Cost,
                Area = request.Area,
                RoomCategory = request.RoomCategory,
                ServicesAndAmenities = request.ServicesAndAmenities,
                WindowsView = request.WindowsView,
                BookingState = BookingState.Вільний.ToString()
            };
            await _service.AddAsync(_mapper.Map<Room>(room), cancellationToken);
            await _service.SaveAsync(cancellationToken);
            return room.Id;
        }
    }
}
