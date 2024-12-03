using MediatR;

namespace Domain.Entities.Command.AuthorCommand
{
    public class AddAuthorCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Bio { get; set; }

        public AddAuthorCommand(string name, string bio)
        {
            Name = name;
            Bio = bio;
        }
    }
}
