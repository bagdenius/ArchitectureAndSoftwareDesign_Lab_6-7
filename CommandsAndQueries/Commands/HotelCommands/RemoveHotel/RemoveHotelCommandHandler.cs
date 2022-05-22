using CommandsAndQueries.Exceptions;
using Entities;
using MediatR;
using UnitOfWOrk.Abstract;

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
            if (hotel == null)
                throw new NotFoundException(nameof(Hotel), request.Id);
            _unitOfWork.Hotels.Remove(hotel);
            await _unitOfWork.SaveAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
