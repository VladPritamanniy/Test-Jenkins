namespace BookStore.Core.Repositories.Base
{
    public interface IRepository<T> : IRepositoryBase<T> where T : class
    {
    }
}
