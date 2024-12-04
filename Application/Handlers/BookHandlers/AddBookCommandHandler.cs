using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Command.BookCommand;
using Infrastructure.Repositories;
using LibraryManagementSystem.Modles;
using MediatR;

namespace Application.Handlers.BookHandlers
{
    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, int>
    {
        private readonly IBookRepository _bookRepository;

        public AddBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<int> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Books
            {
                Title = request.Title,
                AuthorId = request.AuthorId,
                Genre = request.Genre,
                ISBN = request.ISBN,
                Quantity = request.Quantity
            };

            return await _bookRepository.AddBookAsync(book);
        }
    }

}
