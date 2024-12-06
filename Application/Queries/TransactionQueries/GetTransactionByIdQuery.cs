using LibraryManagementSystem.Modles;
using MediatR;

namespace Application.Queries.TransactionQueries
{
    public class GetTransactionByIdQuery : IRequest<Transactions>
    {
        public int TransactionId { get; }

        public GetTransactionByIdQuery(int transactionId)
        {
            TransactionId = transactionId;
        }
    }
}
