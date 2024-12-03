using MediatR;

namespace Application.Handlers.StudentHandlers
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
