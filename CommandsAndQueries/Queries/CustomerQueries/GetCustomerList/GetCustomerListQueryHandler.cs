using AutoMapper;
using Domain;
using MediatR;
using Services.Abstract;
using ViewModels;

namespace CommandsAndQueries.ResumeQueries.GetResumeList
{
    public class GetCustomerListQueryHandler : IRequestHandler<GetCustomerListQuery, List<CustomerVM>>
    {
        private readonly IService<Customer> _service;
        private readonly IMapper _mapper;
        public GetCustomerListQueryHandler(IService<Customer> service, IMapper mapper) =>
            (_service, _mapper) = (service, mapper);

        public async Task<List<CustomerVM>> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
        {
            var customers = await _service.GetAllAsync(cancellationToken);
            return _mapper.Map<List<CustomerVM>>(customers);
        }
    }
}
