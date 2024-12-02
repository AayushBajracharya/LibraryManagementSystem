using LibraryManagementSystem.Modles;
using MediatR;

namespace LibraryManagementSystem.CQRS.Queries
{
    public class GetStudentByIdQuery : IRequest<Students>
    {
        public int Id { get; set; }

        public GetStudentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
