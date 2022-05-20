using CommandsAndQueries.Exceptions;
using Entities;
using MediatR;
using UnitOfWOrk.Abstract;

namespace CommandsAndQueries.Commands.HotelCommands.UpdateHotel
{
    public class UpdateHotelCommandHandler : IRequestHandler<UpdateHotelCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateHotelCommandHandler(IUnitOfWork unitOfWork) =>
            _unitOfWork = unitOfWork;

        public async Task<Unit> Handle(UpdateHotelCommand request, CancellationToken cancellationToken)
        {
            var hotel = await _unitOfWork.Hotels.GetAsync(request.Id, cancellationToken);
            if (hotel == null)
                throw new NotFoundException(nameof(Hotel), request.Id);
            hotel.Id = request.Id;
            hotel.Name = request.Name;
            hotel.Stars = request.Stars;
            hotel.NumberOfFloors = request.NumberOfFloors;
            hotel.Address = request.Address;
            hotel.Phone = request.Phone;
            await _unitOfWork.SaveAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
