namespace Services.Abstract
{
    public interface IService<TDomain> where TDomain : class
    {
        void Add(TDomain domain);
        Task AddAsync(TDomain domain, CancellationToken cancellationToken);
        void Update(TDomain domain);
        void Remove(Guid id);
        void Remove(TDomain domain);
        TDomain Get(Guid id);
        Task<TDomain> GetAsync(Guid id, CancellationToken cancellationToken);
        List<TDomain> GetAll();
        Task<List<TDomain>> GetAllAsync(CancellationToken cancellationToken);
        void Save();
        Task SaveAsync(CancellationToken cancellationToken);
    }
}
