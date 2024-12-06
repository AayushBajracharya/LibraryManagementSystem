using Application.Handlers.StudentHandlers;
using LibraryManagementSystem.CQRS.Commands;
using LibraryManagementSystem.CQRS.Queries;
using LibraryManagementSystem.Modles;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _mediator.Send(new GetAllStudentsQuery());
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _mediator.Send(new GetStudentByIdQuery(id));
            if (student == null) return NotFound();
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] Students student)
        {
            if (student == null) return BadRequest();
            var result = await _mediator.Send(new AddStudentCommand(student.Name, student.Email, student.ContactNumber, student.Department));
            return CreatedAtAction(nameof(GetStudentById), new { id = result }, student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] Students student)
        {
            if (id != student.StudentId) return BadRequest();
            var result = await _mediator.Send(new UpdateStudentCommand(student.StudentId, student.Name, student.Email, student.ContactNumber, student.Department));
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var result = await _mediator.Send(new DeleteStudentCommand(id));
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
