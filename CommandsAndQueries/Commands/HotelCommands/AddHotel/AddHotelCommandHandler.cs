using Entities;
using MediatR;
using UnitOfWOrk.Abstract;

namespace CommandsAndQueries.Commands.HotelCommands.AddHotel
{
    public class AddHotelCommandHandler : IRequestHandler<AddHotelCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddHotelCommandHandler(IUnitOfWork unitOfWork) =>
            _unitOfWork = unitOfWork;

        public async Task<Guid> Handle(AddHotelCommand request, CancellationToken cancellationToken)
        {
            var hotel = new Hotel
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Stars = request.Stars,
                NumberOfFloors = request.NumberOfFloors,
                NumberOfRooms = 0,
                Address = request.Address,
                Phone = request.Phone
            };
            await _unitOfWork.Hotels.AddAsync(hotel, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);
            return hotel.Id;
        }
    }
}
