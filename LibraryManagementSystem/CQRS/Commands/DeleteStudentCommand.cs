using MediatR;

namespace LibraryManagementSystem.CQRS.Commands
{
    public class DeleteStudentCommand : IRequest<bool>
    {
        public int StudentId { get; set; }

        public DeleteStudentCommand(int studentId)
        {
            StudentId = studentId;
        }
    }
}
