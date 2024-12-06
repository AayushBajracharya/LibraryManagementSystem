using Application.Queries.TransactionQueries;
using Infrastructure.Repositories;
using LibraryManagementSystem.Modles;
using MediatR;

namespace Application.Handlers.TransactionHandlers
{
    public class GetTransactionByIdHandler : IRequestHandler<GetTransactionByIdQuery, Transactions>
    {
        private readonly ITransactionRepository _repository;

        public GetTransactionByIdHandler(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public async Task<Transactions> Handle(GetTransactionByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetTransactionByIdAsync(request.TransactionId);
        }
    }
}
