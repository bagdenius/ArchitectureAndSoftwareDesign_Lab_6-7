using AutoMapper;
using MediatR;
using UnitOfWOrk.Abstract;
using ViewModels;

namespace CommandsAndQueries.ResumeQueries.GetCustomerList
{
    public class GetCustomerListQueryHandler : IRequestHandler<GetCustomerListQuery, List<CustomerVM>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetCustomerListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) =>
            (_unitOfWork, _mapper) = (unitOfWork, mapper);

        public async Task<List<CustomerVM>> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
        {
            var customers = await _unitOfWork.Customers.GetAllAsync(cancellationToken);
            return _mapper.Map<List<CustomerVM>>(customers);
        }
    }
}
