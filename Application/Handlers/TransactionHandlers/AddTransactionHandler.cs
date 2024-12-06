using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Command.TransactionCommand;
using Infrastructure.Repositories;
using LibraryManagementSystem.Modles;
using MediatR;

namespace Application.Handlers.TransactionHandlers
{
    public class AddTransactionHandler : IRequestHandler<AddTransactionCommand, int>
    {
        private readonly ITransactionRepository _repository;

        public AddTransactionHandler(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(AddTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = new Transactions
            {
                StudentId = request.StudentId,
                UserId = request.UserId,
                BookId = request.BookId,
                TransactionType = request.TransactionType,
                Date = request.Date
            };

            return await _repository.AddTransactionAsync(transaction);
        }
    }
}
