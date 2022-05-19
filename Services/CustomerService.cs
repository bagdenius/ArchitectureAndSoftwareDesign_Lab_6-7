using AutoMapper;
using Domain;
using Entities;
using Services.Abstract;
using UnitOfWOrk.Abstract;

namespace Services
{
    public class CustomerService : IService<Customer>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper) =>
            (_unitOfWork, _mapper) = (unitOfWork, mapper);

        public void Add(Customer customer) =>
            _unitOfWork.Customers.Add(_mapper.Map<CustomerEntity>(customer));

        public async Task AddAsync(Customer customer, CancellationToken cancellationToken) =>
            await _unitOfWork.Customers.AddAsync(_mapper.Map<CustomerEntity>(customer), cancellationToken);

        public void Update(Customer customer) =>
            _unitOfWork.Customers.Update(_mapper.Map<CustomerEntity>(customer));

        public void Remove(Guid id) =>
            _unitOfWork.Customers.Remove(id);

        public void Remove(Customer customer) =>
            _unitOfWork.Customers.Remove(_mapper.Map<CustomerEntity>(customer));

        public Customer Get(Guid id) =>
            _mapper.Map<Customer>(_unitOfWork.Customers.Get(id));

        public async Task<Customer> GetAsync(Guid id, CancellationToken cancellationToken) =>
            _mapper.Map<Customer>(await _unitOfWork.Customers.GetAsync(id, cancellationToken));

        public List<Customer> GetAll() =>
            _mapper.Map<List<Customer>>(_unitOfWork.Customers.GetAll());

        public async Task<List<Customer>> GetAllAsync(CancellationToken cancellationToken) =>
            _mapper.Map<List<Customer>>(await _unitOfWork.Customers.GetAllAsync(cancellationToken));

        public void Save() => _unitOfWork.Save();

        public async Task SaveAsync(CancellationToken cancellationToken) =>
            await _unitOfWork.SaveAsync(cancellationToken);
    }
}
