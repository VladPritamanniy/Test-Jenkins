using BookStore.Application.Models;

namespace BookStore.Application.Interfaces
{
    public interface IBookService
    {
        public Task<IEnumerable<BookModel>> GetAllBooks();
        public Task<BookModel> GetBookById(int id);
        public Task CreateBook(BookCreateModel book);
        public Task DeleteBookById(int id);
    }
}