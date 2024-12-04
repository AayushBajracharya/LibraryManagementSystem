using Application.Queries.BookQueries;
using Infrastructure.Repositories;
using LibraryManagementSystem.Modles;
using MediatR;

namespace Application.Handlers.BookHandlers
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, IEnumerable<Books>>
    {
        private readonly IBookRepository _bookRepository;

        public GetAllBooksQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<Books>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            return await _bookRepository.GetAllBooksAsync();
        }
    }

}
