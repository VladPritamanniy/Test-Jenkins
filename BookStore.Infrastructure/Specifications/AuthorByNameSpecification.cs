using BookStore.Core.Entities;
using BookStore.Core.Specifications.Base;

namespace BookStore.Infrastructure.Specifications
{
    public class AuthorByIdSpecification : Specification<Author>
    {
        public AuthorByIdSpecification(int id)
        {
            AddCriteria(p=>p.Id== id);
        }
    }
}