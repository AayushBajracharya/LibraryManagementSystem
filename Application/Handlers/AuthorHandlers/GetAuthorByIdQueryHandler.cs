using Application.Queries.AuthorQueries;
using Infrastructure.Repositories;
using LibraryManagementSystem.Modles;
using MediatR;

namespace Application.Handlers.AuthorHandlers
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, Authors>
    {
        private readonly IAuthorRepository _authorRepository;

        public GetAuthorByIdQueryHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<Authors> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            return await _authorRepository.GetAuthorByIdAsync(request.AuthorId);
        }
    }
}
