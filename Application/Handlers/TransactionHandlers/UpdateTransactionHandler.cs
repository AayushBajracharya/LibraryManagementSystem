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
    public class UpdateTransactionHandler : IRequestHandler<UpdateTransactionCommand, bool>
    {
        private readonly ITransactionRepository _repository;

        public UpdateTransactionHandler(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = new Transactions
            {
                TransactionId = request.TransactionId,
                StudentId = request.StudentId,
                UserId = request.UserId,
                BookId = request.BookId,
                TransactionType = request.TransactionType,
                Date = request.Date
            };

            return await _repository.UpdateTransactionAsync(transaction);
        }
    }
}
