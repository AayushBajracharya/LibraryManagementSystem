using LibraryManagementSystem.Modles;
using MediatR;

namespace Application.Queries.AuthorQueries
{
    public class GetAllAuthorsQuery : IRequest<IEnumerable<Authors>>
    {
    }

}
