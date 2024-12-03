using Application.Handlers.StudentHandlers;
using LibraryManagementSystem.CQRS.Commands;
using LibraryManagementSystem.Modles;
using LibraryManagementSystem.Repositories;
using MediatR;

namespace LibraryManagementSystem.CQRS.Commands.Handlers
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, bool>
    {
        private readonly IStudentRepository _studentRepository;

        public UpdateStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<bool> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = new Students
            {
                StudentId = request.StudentId,
                Name = request.Name,
                Email = request.Email,
                ContactNumber = request.ContactNumber,
                Department = request.Department
            };

            return await _studentRepository.UpdateStudentAsync(student);
        }
    }
}
