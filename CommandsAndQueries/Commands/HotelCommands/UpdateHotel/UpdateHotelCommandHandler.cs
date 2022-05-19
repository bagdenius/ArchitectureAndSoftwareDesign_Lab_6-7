using AutoMapper;
using CommandsAndQueries.Exceptions;
using Domain;
using MediatR;
using Services.Abstract;
using ViewModels;

namespace CommandsAndQueries.Commands.HotelCommands.UpdateHotel
{
    public class UpdateHotelCommandHandler : IRequestHandler<UpdateHotelCommand>
    {
        private readonly IService<Hotel> _service;
        private readonly IMapper _mapper;
        public UpdateHotelCommandHandler(IService<Hotel> service, IMapper mapper) =>
            (_service, _mapper) = (service, mapper);

        public async Task<Unit> Handle(UpdateHotelCommand request, CancellationToken cancellationToken)
        {
            var hotel = _mapper.Map<HotelVM>(await _service.GetAsync(request.Id, cancellationToken));
            if (hotel == null || hotel.Id != request.Id)
                throw new NotFoundException(nameof(Customer), request.Id);
            hotel.Id = request.Id;
            hotel.Name = request.Name;
            hotel.Stars = request.Stars;
            hotel.NumberOfFloors = request.NumberOfFloors;
            hotel.NumberOfRooms = request.NumberOfRooms;
            hotel.Address = request.Address;
            hotel.Phone = request.Phone;
            await _service.SaveAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
