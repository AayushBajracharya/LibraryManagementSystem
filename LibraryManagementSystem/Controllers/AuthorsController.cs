using Application.Queries.AuthorQueries;
using Application.Services;
using Domain.Entities.Command.AuthorCommand;
using LibraryManagementSystem.Modles;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAuthors()
        {
            var authors = await _mediator.Send(new GetAllAuthorsQuery());
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorById(int id)
        {
            var author = await _mediator.Send(new GetAuthorByIdQuery(id));
            if (author == null) return NotFound();
            return Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> AddAuthor([FromBody] Authors author)
        {
            if (author == null) return BadRequest();
            var result = await _mediator.Send(new AddAuthorCommand(author.Name, author.Bio));
            return CreatedAtAction(nameof(GetAuthorById), new { id = result }, author);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, [FromBody] Authors author)
        {
            if (id != author.AuthorID) return BadRequest();
            var result = await _mediator.Send(new UpdateAuthorCommand(id, author.Name, author.Bio));
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var result = await _mediator.Send(new DeleteAuthorCommand(id));
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
