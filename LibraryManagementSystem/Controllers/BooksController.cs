using Application.Queries.BookQueries;
using Application.Services;
using Domain.Entities.Command.BookCommand;
using LibraryManagementSystem.Modles;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _mediator.Send(new GetAllBooksQuery());
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _mediator.Send(new GetBookByIdQuery(id));
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] Books book)
        {
            if (book == null) return BadRequest();
            var result = await _mediator.Send(new AddBookCommand(book.Title, book.AuthorId, book.Genre, book.ISBN, book.Quantity));
            return CreatedAtAction(nameof(GetBookById), new { id = result }, book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] Books book)
        {
            if (id != book.BookId) return BadRequest();
            var result = await _mediator.Send(new UpdateBookCommand(id, book.Title, book.AuthorId, book.Genre, book.ISBN, book.Quantity));
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var result = await _mediator.Send(new DeleteBookCommand(id));
            if (!result) return NotFound();
            return NoContent();
        }
    }

}
