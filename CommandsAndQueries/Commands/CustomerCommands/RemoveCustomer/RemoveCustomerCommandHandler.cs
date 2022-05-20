using CommandsAndQueries.Exceptions;
using Entities;
using MediatR;
using UnitOfWOrk.Abstract;
using ViewModels.enums;

namespace CommandsAndQueries.ResumeCommands.RemoveResume
{
    public class RemoveCustomerCommandHandler : IRequestHandler<RemoveCustomerCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public RemoveCustomerCommandHandler(IUnitOfWork unitOfWork) =>
            _unitOfWork = unitOfWork;

        public async Task<Unit> Handle(RemoveCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.Customers.GetAsync(request.Id, cancellationToken);
            if (customer == null)
                throw new NotFoundException(nameof(Customer), request.Id);
            _unitOfWork.Customers.Remove(customer);
            var room = _unitOfWork.Rooms.Get(customer.RoomId);
            room.BookingState = BookingState.Вільний.ToString();
            room.BookingDates = string.Empty;
            await _unitOfWork.SaveAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
