using Domain.Entities.Command.AuthorCommand;
using Infrastructure.Repositories;
using LibraryManagementSystem.Modles;
using MediatR;

namespace Application.Handlers.AuthorHandlers
{
    public class AddAuthorCommandHandler : IRequestHandler<AddAuthorCommand, int>
    {
        private readonly IAuthorRepository _authorRepository;

        public AddAuthorCommandHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<int> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = new Authors
            {
                Name = request.Name,
                Bio = request.Bio
            };

            return await _authorRepository.AddAuthorAsync(author);
        }
    }

}
