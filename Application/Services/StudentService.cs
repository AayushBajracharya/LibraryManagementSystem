using Application.Handlers.StudentHandlers;
using LibraryManagementSystem.CQRS.Commands;
using LibraryManagementSystem.CQRS.Queries;
using LibraryManagementSystem.Modles;
using LibraryManagementSystem.Repositories;
using MediatR;

namespace LibraryManagementSystem.Services
{
    public class StudentService : IStudentService
    {
        private readonly IMediator _mediator;

        public StudentService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IEnumerable<Students>> GetAllStudentsAsync()
        {
            return await _mediator.Send(new GetAllStudentsQuery());
        }

        public async Task<Students> GetStudentByIdAsync(int id)
        {
            return await _mediator.Send(new GetStudentByIdQuery(id));
        }

        public async Task<int> AddStudentAsync(Students student)
        {
            return await _mediator.Send(new AddStudentCommand(student.Name, student.Email, student.ContactNumber, student.Department));
        }

        public async Task<bool> UpdateStudentAsync(Students student)
        {
            return await _mediator.Send(new UpdateStudentCommand(student.StudentId, student.Name, student.Email, student.ContactNumber, student.Department));
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            return await _mediator.Send(new DeleteStudentCommand(id));
        }
    }
}
