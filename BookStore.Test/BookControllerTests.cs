using BookStore.API.Controllers;
using BookStore.Application.Interfaces;
using BookStore.Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace BookStore.Test
{
    public class BookControllerTests
    {
        private readonly Mock<IBookService> _bookServiceMock;
        private readonly Mock<ILogger<BookController>> _loggerMock;
        private readonly BookController _controller;

        public BookControllerTests()
        {
            _bookServiceMock = new Mock<IBookService>();
            _loggerMock = new Mock<ILogger<BookController>>();
            _controller = new BookController(_bookServiceMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task GetAllBooks_ReturnsOkResult_WithListOfBooks()
        {
            var books = new List<BookModel>
            {
                new BookModel { Title = "Book 1", Price = 10.99M },
                new BookModel { Title = "Book 2", Price = 15.99M }
            };

            _bookServiceMock.Setup(service => service.GetAllBooks()).ReturnsAsync(books);

            var result = await _controller.GetAllBooks();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnBooks = Assert.IsAssignableFrom<IEnumerable<BookModel>>(okResult.Value);
            Assert.Equal(2, returnBooks.Count());
        }

        [Fact]
        public async Task GetBookById_ExistingId_ReturnsOkResult_WithBook()
        {
            int bookId = 1;
            var book = new BookModel { Title = "Book 1", Price = 10.99M };

            _bookServiceMock.Setup(service => service.GetBookById(bookId)).ReturnsAsync(book);

            var result = await _controller.GetBookById(bookId);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(book, okResult.Value);
        }

        [Fact]
        public async Task CreateBook_ValidModel_ReturnsOkResult()
        {
            var bookCreateModel = new BookCreateModel
                { Title = "New Book", Price = 20.99M, AuthorsName = new string[] { "Author 1" } };

            var result = await _controller.CreateBook(bookCreateModel);

            Assert.IsType<OkResult>(result);
            _bookServiceMock.Verify(service => service.CreateBook(bookCreateModel), Times.Once);
        }

        [Fact]
        public async Task ChangeBookPrice_ValidModel_ReturnsOkResult()
        {
            var bookPriceModel = new BookPriceModel { Id = 1, Price = 25.99M };

            var result = await _controller.ChangeBookPrice(bookPriceModel);

            Assert.IsType<OkResult>(result);
            _bookServiceMock.Verify(service => service.ChangeBookPrice(bookPriceModel), Times.Once);
        }

        [Fact]
        public async Task DeleteBookById_ExistingId_ReturnsOkResult()
        {
            int bookId = 1;
            _bookServiceMock.Setup(service => service.DeleteBookById(bookId)).Returns(Task.CompletedTask);

            var result = await _controller.DeleteBookById(bookId);

            Assert.IsType<OkResult>(result);
            _bookServiceMock.Verify(service => service.DeleteBookById(bookId), Times.Once);
        }
    }
}