using Domain.Entities.Command.TransactionCommand;
using Infrastructure.Repositories;
using MediatR;

namespace Application.Handlers.TransactionHandlers
{
    public class DeleteTransactionHandler : IRequestHandler<DeleteTransactionCommand, bool>
    {
        private readonly ITransactionRepository _repository;

        public DeleteTransactionHandler(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
        {
            return await _repository.DeleteTransactionAsync(request.TransactionId);
        }
    }
}
