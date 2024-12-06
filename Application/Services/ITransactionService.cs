using LibraryManagementSystem.Modles;

namespace Application.Services
{
    public interface ITransactionService
    {
        Task<IEnumerable<Transactions>> GetAllTransactionsAsync();
        Task<Transactions> GetTransactionByIdAsync(int id);
        Task<int> AddTransactionAsync(Transactions transaction);
        Task<bool> UpdateTransactionAsync(Transactions transaction);
        Task<bool> DeleteTransactionAsync(int id);
    }
}
