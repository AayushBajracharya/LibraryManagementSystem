using Application.Handlers.StudentHandlers;
using LibraryManagementSystem.CQRS.Commands;
using LibraryManagementSystem.Repositories;
using MediatR;

namespace LibraryManagementSystem.CQRS.Queries.Handlers
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, bool>
    {
        private readonly IStudentRepository _studentRepository;

        public DeleteStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<bool> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            return await _studentRepository.DeleteStudentAsync(request.StudentId);
        }
    }
}
