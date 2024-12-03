using MediatR;

namespace Domain.Entities.Command.AuthorCommand
{
    public class UpdateAuthorCommand : IRequest<bool>
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }

        public UpdateAuthorCommand(int authorId, string name, string bio)
        {
            AuthorId = authorId;
            Name = name;
            Bio = bio;
        }
    }
}
