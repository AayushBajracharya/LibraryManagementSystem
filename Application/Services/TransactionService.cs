using Infrastructure.Repositories;
using LibraryManagementSystem.Modles;

namespace Application.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<IEnumerable<Transactions>> GetAllTransactionsAsync()
        {
            return await _transactionRepository.GetAllTransactionsAsync();
        }

        public async Task<Transactions> GetTransactionByIdAsync(int id)
        {
            return await _transactionRepository.GetTransactionByIdAsync(id);
        }

        public async Task<int> AddTransactionAsync(Transactions transaction)
        {
            return await _transactionRepository.AddTransactionAsync(transaction);
        }

        public async Task<bool> UpdateTransactionAsync(Transactions transaction)
        {
            return await _transactionRepository.UpdateTransactionAsync(transaction);
        }

        public async Task<bool> DeleteTransactionAsync(int id)
        {
            return await _transactionRepository.DeleteTransactionAsync(id);
        }
    }
}
