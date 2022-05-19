using AutoMapper;
using Domain;
using MediatR;
using Queries.Exceptions;
using Services.Abstract;
using ViewModels;

namespace Queries.ResumeQueries.GetResume
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, ResumeVM>
    {
        private readonly IService<Resume> _service;
        private readonly IMapper _mapper;
        public GetCustomerQueryHandler(IService<Resume> service, IMapper mapper) =>
            (_service, _mapper) = (service, mapper);

        public async Task<ResumeVM> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var resume = await _service.GetAsync(request.Id, cancellationToken);
            if (resume == null || resume.Id != request.Id)
                throw new NotFoundException(nameof(Resume), request.Id);
            return _mapper.Map<ResumeVM>(resume);
        }
    }
}
