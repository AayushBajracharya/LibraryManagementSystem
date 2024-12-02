using LibraryManagementSystem.Modles;
using LibraryManagementSystem.Repositories;
using MediatR;

namespace LibraryManagementSystem.CQRS.Queries.Handlers
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, Students>
    {
        private readonly IStudentRepository _studentRepository;

        public GetStudentByIdQueryHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Students> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            return await _studentRepository.GetStudentByIdAsync(request.Id);
        }
    }
}
