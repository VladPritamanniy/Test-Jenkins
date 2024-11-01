using BookStore.Application.Models;
using BookStore.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BookStore.Core.Exceptions;

namespace BookStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BookController : ControllerBase
    {
        public readonly IBookService _bookService;
        public readonly ILogger<BookController> _logger;

        public BookController(IBookService bookService, ILogger<BookController> logger)
        {
            _bookService = bookService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks() =>
            Ok(await _bookService.GetAllBooks());

        [HttpGet]
        public async Task<IActionResult> GetBookById([FromQuery] int id) =>
            Ok(await _bookService.GetBookById(id));

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromForm] BookCreateModel book)
        {
            await _bookService.CreateBook(book);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> ChangeBookPrice([FromForm] BookPriceModel book)
        {
            await _bookService.ChangeBookPrice(book);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBookById([FromQuery] int id)
        {
            try
            {
                await _bookService.DeleteBookById(id);
                return Ok();
            }
            catch (BookNotFoundException e)
            {
                _logger.LogError(e.Message);
                return NotFound(e.Message);
            }
        }
    }
}