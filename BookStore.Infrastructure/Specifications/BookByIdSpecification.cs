using BookStore.Core.Entities;
using BookStore.Core.Specifications.Base;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Specifications
{
    public class BookByIdSpecification : Specification<Book>
    {
        public BookByIdSpecification(int id)
        {
            AddCriteria(p=>p.Id==id);
            AddCustomQuery(p=>p.Include(b=> b.AuthorsLink).ThenInclude(ba=> ba.Author));
        }
    }
}