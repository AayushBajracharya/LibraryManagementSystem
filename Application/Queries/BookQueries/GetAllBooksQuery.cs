using LibraryManagementSystem.Modles;
using MediatR;

namespace Application.Queries.BookQueries
{
    public class GetAllBooksQuery : IRequest<IEnumerable<Books>>
    {
    }

}
