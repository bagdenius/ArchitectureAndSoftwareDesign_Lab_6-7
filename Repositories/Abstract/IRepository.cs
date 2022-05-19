﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Repositories.Abstract
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        Task AddAsync(TEntity entity, CancellationToken cancellationToken);
        void Update(TEntity entity);
        void Remove(Guid id);
        void Remove(TEntity entity);
        TEntity Get(Guid id);
        Task<TEntity> GetAsync(Guid id, CancellationToken cancellationToken);
        List<TEntity> GetAll();
        Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken);
    }
}
