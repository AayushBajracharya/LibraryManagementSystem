using Application.Queries.AuthorQueries;
using Infrastructure.Repositories;
using LibraryManagementSystem.Modles;
using MediatR;

namespace Application.Handlers.AuthorHandlers
{
    public class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQuery, IEnumerable<Authors>>
    {
        private readonly IAuthorRepository _authorRepository;

        public GetAllAuthorsQueryHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<IEnumerable<Authors>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            return await _authorRepository.GetAllAuthorsAsync();
        }
    }
}
