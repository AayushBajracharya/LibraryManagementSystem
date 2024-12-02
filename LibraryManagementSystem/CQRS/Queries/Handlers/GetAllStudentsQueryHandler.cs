﻿using LibraryManagementSystem.Modles;
using LibraryManagementSystem.Repositories;
using MediatR;

namespace LibraryManagementSystem.CQRS.Queries.Handlers
{
    public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, IEnumerable<Students>>
    {
        private readonly IStudentRepository _studentRepository;

        public GetAllStudentsQueryHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<Students>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            return await _studentRepository.GetAllStudentsAsync();
        }
    }
}
