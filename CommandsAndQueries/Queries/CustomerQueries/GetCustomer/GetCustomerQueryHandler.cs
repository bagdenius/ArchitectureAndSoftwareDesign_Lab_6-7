using AutoMapper;
using Domain;
using MediatR;
using CommandsAndQueries.Exceptions;
using Services.Abstract;
using ViewModels;

namespace CommandsAndQueries.ResumeQueries.GetResume
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, CustomerVM>
    {
        private readonly IService<Customer> _service;
        private readonly IMapper _mapper;
        public GetCustomerQueryHandler(IService<Customer> service, IMapper mapper) =>
            (_service, _mapper) = (service, mapper);

        public async Task<CustomerVM> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var customer = await _service.GetAsync(request.Id, cancellationToken);
            if (customer == null || customer.Id != request.Id)
                throw new NotFoundException(nameof(Customer), request.Id);
            return _mapper.Map<CustomerVM>(customer);
        }
    }
}
