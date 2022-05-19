using AutoMapper;
using Domain;
using Entities;
using Services.Abstract;
using UnitOfWOrk.Abstract;

namespace Services
{
    public class HotelService : IService<Hotel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HotelService(IUnitOfWork unitOfWork, IMapper mapper) =>
            (_unitOfWork, _mapper) = (unitOfWork, mapper);

        public void Add(Hotel hotel) =>
            _unitOfWork.Hotels.Add(_mapper.Map<HotelEntity>(hotel));

        public async Task AddAsync(Hotel hotel, CancellationToken cancellationToken) =>
            await _unitOfWork.Hotels.AddAsync(_mapper.Map<HotelEntity>(hotel), cancellationToken);

        public void Update(Hotel hotel) =>
            _unitOfWork.Hotels.Update(_mapper.Map<HotelEntity>(hotel));

        public void Remove(Guid id) =>
            _unitOfWork.Hotels.Remove(id);

        public void Remove(Hotel hotel) =>
            _unitOfWork.Hotels.Remove(_mapper.Map<HotelEntity>(hotel));

        public Hotel Get(Guid id) =>
            _mapper.Map<Hotel>(_unitOfWork.Hotels.Get(id));

        public async Task<Hotel> GetAsync(Guid id, CancellationToken cancellationToken) =>
            _mapper.Map<Hotel>(await _unitOfWork.Hotels.GetAsync(id, cancellationToken));

        public List<Hotel> GetAll() =>
            _mapper.Map<List<Hotel>>(_unitOfWork.Hotels.GetAll());

        public async Task<List<Hotel>> GetAllAsync(CancellationToken cancellationToken) =>
            _mapper.Map<List<Hotel>>(await _unitOfWork.Hotels.GetAllAsync(cancellationToken));

        public void Save() => _unitOfWork.Save();

        public async Task SaveAsync(CancellationToken cancellationToken) =>
            await _unitOfWork.SaveAsync(cancellationToken);
    }
}
