using BookStore.Core.Entities;
using BookStore.Core.Specifications.Base;

namespace BookStore.Infrastructure.Specifications
{
    public class AuthorByNameSpecification : Specification<Author>
    {
        public AuthorByNameSpecification(string name)
        {
            AddCriteria(p=>p.Name==name);
        }
    }
}