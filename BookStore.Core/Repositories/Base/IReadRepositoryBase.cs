﻿using BookStore.Core.Specifications.Base;

namespace BookStore.Core.Repositories.Base
{
    public interface IReadRepositoryBase<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAll();
        Task<IReadOnlyList<T>> ToListAsync(ISpecification<T> spec);
        Task<IReadOnlyList<TResult>> ToListAsync<TResult>(ISpecification<T, TResult> spec);
        Task<T?> FirstOrDefaultAsync(ISpecification<T> specification);
        Task<TResult?> FirstOrDefaultAsync<TResult>(ISpecification<T, TResult> specification);
        Task<T?> SingleOrDefaultAsync(ISpecification<T> specification);
        Task<TResult?> SingleOrDefaultAsync<TResult>(ISpecification<T, TResult> specification);
        Task<int> CountAsync(ISpecification<T> specification);
        Task<int> CountAsync();
        Task<TResult[]?> ToArrayAsync<TResult>(ISpecification<T, TResult> spec);
        Task<bool> AnyAsync(ISpecification<T> specification);
    }
}
