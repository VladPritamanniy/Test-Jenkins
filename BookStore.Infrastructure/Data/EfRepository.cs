using BookStore.Core.Repositories.Base;
using BookStore.Infrastructure.Repositories.Base;

namespace BookStore.Infrastructure.Data
{
    public class EfRepository<T> : Repository<T>, IReadRepository<T>, IRepository<T> where T : class
    {
        public EfRepository(AppDbContext dbContext) 
            : base(dbContext) { }
    }
}
