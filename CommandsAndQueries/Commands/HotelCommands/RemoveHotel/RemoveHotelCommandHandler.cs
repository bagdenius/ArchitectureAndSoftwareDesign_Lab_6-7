using MediatR;
using CommandsAndQueries.Exceptions;
using UnitOfWOrk.Abstract;
using Entities;

namespace CommandsAndQueries.Commands.HotelCommands.RemoveHotel
{
    public class RemoveHotelCommandHandler : IRequestHandler<RemoveHotelCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public RemoveHotelCommandHandler(IUnitOfWork unitOfWork) =>
            _unitOfWork = unitOfWork;

        public async Task<Unit> Handle(RemoveHotelCommand request, CancellationToken cancellationToken)
        {
            var hotel = await _unitOfWork.Hotels.GetAsync(request.Id, cancellationToken);
            if (hotel == null || hotel.Id != request.Id)
                throw new NotFoundException(nameof(Hotel), request.Id);
            _unitOfWork.Hotels.Remove(hotel);
            await _unitOfWork.SaveAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
