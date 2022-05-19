using AutoMapper;
using Queries.Exceptions;
using Domain;
using MediatR;
using Services.Abstract;

namespace Queries.ResumeCommands.RemoveResume
{
    public class RemoveCustomerCommandHandler : IRequestHandler<RemoveCustomerCommand>
    {
        private readonly IService<Customer> _service;
        private readonly IMapper _mapper;
        public RemoveCustomerCommandHandler(IService<Customer> service, IMapper mapper) =>
            (_service, _mapper) = (service, mapper);

        public async Task<Unit> Handle(RemoveCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _service.GetAsync(request.Id, cancellationToken);
            if (customer == null || customer.Id != request.Id)
                throw new NotFoundException(nameof(Customer), request.Id);
            _service.Remove(customer.Id);
            await _service.SaveAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
