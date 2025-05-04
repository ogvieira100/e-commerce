﻿using Dapper;
using DeveloperEvaluation.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Data
{

    public interface IRepositoryConsult<TEntity> : IDisposable where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> SearchAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> SearchAsync(string query, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity2>> SearchAsync<TEntity2>(string query, CancellationToken cancellationToken = default) where TEntity2: class;
        IQueryable<TEntity> GetQueryable();
        Task<TEntity?> GetByIdAsync(long id, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    }
}
