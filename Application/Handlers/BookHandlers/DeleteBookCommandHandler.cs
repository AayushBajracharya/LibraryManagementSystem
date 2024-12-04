using Domain.Entities.Command.BookCommand;
using Infrastructure.Repositories;
using MediatR;

namespace Application.Handlers.BookHandlers
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, bool>
    {
        private readonly IBookRepository _bookRepository;

        public DeleteBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            return await _bookRepository.DeleteBookAsync(request.BookId);
        }
    }

}
