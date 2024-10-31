using AutoMapper;
using BookStore.Application.Interfaces;
using BookStore.Application.Models;
using BookStore.Core.Entities;
using BookStore.Core.Exceptions;
using BookStore.Core.Repositories.Base;
using BookStore.Infrastructure.Specifications;

namespace BookStore.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<Author> _authorRepository;
        private readonly IRepository<BookAuthor> _bookAuthorRepository;
        private readonly IMapper _mapper;

        public BookService(IRepository<Book> bookRepository, IRepository<Author> authorRepository, IRepository<BookAuthor> bookAuthorRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _bookAuthorRepository = bookAuthorRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookModel>> GetAllBooks()
        {
            var result = await _bookRepository.ToListAsync(new BookGetAllSpecification());
            return _mapper.Map<IEnumerable<BookModel>>(result);
        }

        public async Task<BookModel> GetBookById(int id)
        {
            var result = await _bookRepository.FirstOrDefaultAsync(new BookByIdSpecification(id));
            return _mapper.Map<BookModel>(result);
        }

        public async Task CreateBook(BookCreateModel book)
        {
            var newBook = new Book
            {
                Title = book.Title,
                Price = book.Price
            };
            await _bookRepository.AddAsync(newBook);

            var authorsToAdd = new List<Author>();
            var bookAuthorsToAdd = new List<BookAuthor>();
            byte order = 0;

            foreach (var authorName in book.AuthorsName)
            {
                var existingAuthor = await _authorRepository.FirstOrDefaultAsync(new AuthorByNameSpecification(authorName));

                Author author;
                if (existingAuthor == null)
                {
                    author = new Author
                    {
                        Name = authorName,
                    };
                    authorsToAdd.Add(author);
                }
                else
                {
                    author = existingAuthor;
                }

                bookAuthorsToAdd.Add(new BookAuthor
                {
                    Author = author,
                    Book = newBook,
                    DisplayOrder = order++
                });
            }

            if (authorsToAdd.Any())
            {
                await _authorRepository.AddRangeAsync(authorsToAdd);
            }

            await _bookAuthorRepository.AddRangeAsync(bookAuthorsToAdd);
            await _bookRepository.SaveChangesAsync();
        }

        public async Task DeleteBookById(int id)
        {
            var book = await _bookRepository.FirstOrDefaultAsync(new BookByIdSpecification(id));
            if (book == null)
            {
                throw new BookNotFoundException(id);
            }

            book!.SoftDeleted = true;
            await _bookRepository.SaveChangesAsync();
        }
    }
}