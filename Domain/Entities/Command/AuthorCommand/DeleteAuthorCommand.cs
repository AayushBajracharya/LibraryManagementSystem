using MediatR;

namespace Domain.Entities.Command.AuthorCommand
{
    public class DeleteAuthorCommand : IRequest<bool>
    {
        public int AuthorId { get; set; }

        public DeleteAuthorCommand(int authorId)
        {
            AuthorId = authorId;
        }
    }
}
