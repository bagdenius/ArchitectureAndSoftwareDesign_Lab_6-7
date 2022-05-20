using CommandsAndQueries.Exceptions;
using Entities;
using MediatR;
using UnitOfWOrk.Abstract;

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
            if (customer == null || customer.Id != request.Id)
                throw new NotFoundException(nameof(Customer), request.Id);
            _unitOfWork.Customers.Remove(customer);
            await _unitOfWork.SaveAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
