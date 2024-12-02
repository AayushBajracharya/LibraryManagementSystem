using LibraryManagementSystem.Modles;
using LibraryManagementSystem.Repositories;
using MediatR;

namespace LibraryManagementSystem.CQRS.Commands.Handlers
{
    public class AddStudentCommandHandler : IRequestHandler<AddStudentCommand, int>
    {
        private readonly IStudentRepository _studentRepository;

        public AddStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<int> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var student = new Students
            {
                Name = request.Name,
                Email = request.Email,
                ContactNumber = request.ContactNumber,
                Department = request.Department
            };

            return await _studentRepository.AddStudentAsync(student);
        }
    }
}
