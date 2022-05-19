using AutoMapper;
using Domain;
using MediatR;
using CommandsAndQueries.Exceptions;
using Services.Abstract;

namespace CommandsAndQueries.Commands.HotelCommands.RemoveHotel
{
    public class RemoveHotelCommandHandler : IRequestHandler<RemoveHotelCommand>
    {
        private readonly IService<Hotel> _service;
        private readonly IMapper _mapper;
        public RemoveHotelCommandHandler(IService<Hotel> service, IMapper mapper) =>
            (_service, _mapper) = (service, mapper);

        public async Task<Unit> Handle(RemoveHotelCommand request, CancellationToken cancellationToken)
        {
            var hotel = await _service.GetAsync(request.Id, cancellationToken);
            if (hotel == null || hotel.Id != request.Id)
                throw new NotFoundException(nameof(Customer), request.Id);
            _service.Remove(hotel.Id);
            await _service.SaveAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
