using AutoMapper;
using MediatR;
using CommandsAndQueries.Exceptions;
using ViewModels;
using UnitOfWOrk.Abstract;
using Entities;

namespace CommandsAndQueries.ResumeQueries.GetResume
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
