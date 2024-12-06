using LibraryManagementSystem.Modles;
using MediatR;

namespace Application.Queries.TransactionQueries
{
    public class GetAllTransactionsQuery : IRequest<IEnumerable<Transactions>> { }
}
