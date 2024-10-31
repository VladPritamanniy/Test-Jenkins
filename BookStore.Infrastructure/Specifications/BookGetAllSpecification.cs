using BookStore.Core.Entities;
using BookStore.Core.Specifications.Base;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Specifications
{
    public class BookGetAllSpecification : Specification<Book>
    {
        public BookGetAllSpecification()
        {
            AddCustomQuery(books => books
                .Include(b => b.AuthorsLink)
                .ThenInclude(p=>p.Author)
                .OrderBy(b => b.AuthorsLink.OrderBy(al => al.DisplayOrder).First().DisplayOrder));
            AddInclude(b => b.AuthorsLink);
        }
    }
}