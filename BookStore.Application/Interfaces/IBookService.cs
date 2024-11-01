using BookStore.Application.Models;

namespace BookStore.Application.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookModel>> GetAllBooks();
        Task<BookModel> GetBookById(int id);
        Task CreateBook(BookCreateModel book);
        Task ChangeBookPrice(BookPriceModel book);
        Task DeleteBookById(int id);
    }
}