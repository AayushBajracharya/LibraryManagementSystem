
using Application.Queries.BookQueries;
using Infrastructure.Repositories;
using LibraryManagementSystem.Modles;
using MediatR;

namespace Application.Handlers.BookHandlers
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, Books>
    {
        private readonly IBookRepository _bookRepository;

        public GetBookByIdQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Books> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            return await _bookRepository.GetBookByIdAsync(request.BookId);
        }
    }

}
