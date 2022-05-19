﻿using Database;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstract;

namespace Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(DatabaseContext context) =>
            (_context, _dbSet) = (context, context.Set<TEntity>());

        public void Add(TEntity entity) =>
            _dbSet.Add(entity);

        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken) =>
            await _dbSet.AddAsync(entity, cancellationToken);

        public void Update(TEntity entity) =>
            _context.Entry(entity).State = EntityState.Modified;

        public void Remove(Guid id) =>
            _dbSet.Remove(_dbSet.Find(id));

        public void Remove(TEntity entity) =>
            _dbSet.Remove(entity);

        public TEntity Get(Guid id) =>
            _dbSet.Find(id);

        public async Task<TEntity> GetAsync(Guid id, CancellationToken cancellationToken) =>
            await _dbSet.FindAsync(new object[] { id }, cancellationToken);

        public List<TEntity> GetAll() =>
            _dbSet.AsNoTracking().ToList();

        public async Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken) =>
            await _dbSet.AsNoTracking().ToListAsync(cancellationToken);
    }
}