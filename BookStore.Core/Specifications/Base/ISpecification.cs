using System.Linq.Expressions;

namespace BookStore.Core.Specifications.Base
{
    public interface ISpecification<T, TResult> : ISpecification<T>
    {
        Expression<Func<T, TResult>>? Selector { get; }
        Expression<Func<T, IEnumerable<TResult>>>? SelectorMany { get; }
    }

    public interface ISpecification<T>
    {
        Func<IQueryable<T>, IQueryable<T>>? CustomQuery { get; }
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, object>>> Includes { get; }
        List<Expression<Func<T, object>>> OrderBy { get; }
        List<Expression<Func<T, object>>> OrderByDescending { get; }
        bool AsNoTracking { get; }
        bool AsSplitQuery { get; }
        bool AsNoTrackingWithIdentityResolution { get; }
        int? Take { get; }
        int? Skip { get; }
    }
}
