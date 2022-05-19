using AutoMapper;
using Domain;
using MediatR;
using Services.Abstract;
using ViewModels;

namespace CommandsAndQueries.Commands.HotelCommands.AddHotel
{
    public class AddHotelCommandHandler : IRequestHandler<AddHotelCommand, Guid>
    {
        private readonly IService<Hotel> _service;
        private readonly IMapper _mapper;
        public AddHotelCommandHandler(IService<Hotel> service, IMapper mapper) =>
            (_service, _mapper) = (service, mapper);

        public async Task<Guid> Handle(AddHotelCommand request, CancellationToken cancellationToken)
        {
            var hotel = new HotelVM
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Stars = request.Stars,
                NumberOfFloors = request.NumberOfFloors,
                NumberOfRooms = request.NumberOfRooms,
                Address = request.Address,
                Phone = request.Phone
            };
            await _service.AddAsync(_mapper.Map<Hotel>(hotel), cancellationToken);
            await _service.SaveAsync(cancellationToken);
            return hotel.Id;
        }
    }
}
