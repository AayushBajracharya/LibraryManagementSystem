using LibraryManagementSystem.Modles;
using MediatR;

namespace LibraryManagementSystem.CQRS.Queries
{
    public class GetAllStudentsQuery : IRequest<IEnumerable<Students>> { }
}
