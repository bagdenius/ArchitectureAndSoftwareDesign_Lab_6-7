using AutoMapper;
using CommandsAndQueries.Exceptions;
using Entities;
using MediatR;
using UnitOfWOrk.Abstract;
using ViewModels;

namespace CommandsAndQueries.ResumeQueries.GetCustomer
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, CustomerVM>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetCustomerQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) =>
            (_unitOfWork, _mapper) = (unitOfWork, mapper);

        public async Task<CustomerVM> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.Customers.GetAsync(request.Id, cancellationToken);
            if (customer == null || customer.Id != request.Id)
                throw new NotFoundException(nameof(Customer), request.Id);
            return _mapper.Map<CustomerVM>(customer);
        }
    }
}
