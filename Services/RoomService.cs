using AutoMapper;
using Domain;
using Entities;
using Services.Abstract;
using UnitOfWOrk.Abstract;

namespace Services
{
    public class RoomService : IService<Room>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RoomService(IUnitOfWork unitOfWork, IMapper mapper) =>
            (_unitOfWork, _mapper) = (unitOfWork, mapper);

        public void Add(Room room) =>
            _unitOfWork.Rooms.Add(_mapper.Map<RoomEntity>(room));

        public async Task AddAsync(Room room, CancellationToken cancellationToken) =>
            await _unitOfWork.Rooms.AddAsync(_mapper.Map<RoomEntity>(room), cancellationToken);

        public void Update(Room room) =>
            _unitOfWork.Rooms.Update(_mapper.Map<RoomEntity>(room));

        public void Remove(Guid id) =>
            _unitOfWork.Rooms.Remove(id);

        public void Remove(Room room) =>
            _unitOfWork.Rooms.Remove(_mapper.Map<RoomEntity>(room));

        public Room Get(Guid id) =>
            _mapper.Map<Room>(_unitOfWork.Rooms.Get(id));

        public async Task<Room> GetAsync(Guid id, CancellationToken cancellationToken) =>
            _mapper.Map<Room>(await _unitOfWork.Rooms.GetAsync(id, cancellationToken));

        public List<Room> GetAll() =>
            _mapper.Map<List<Room>>(_unitOfWork.Rooms.GetAll());

        public async Task<List<Room>> GetAllAsync(CancellationToken cancellationToken) =>
            _mapper.Map<List<Room>>(await _unitOfWork.Rooms.GetAllAsync(cancellationToken));

        public void Save() => _unitOfWork.Save();

        public async Task SaveAsync(CancellationToken cancellationToken) =>
            await _unitOfWork.SaveAsync(cancellationToken);
    }
}
