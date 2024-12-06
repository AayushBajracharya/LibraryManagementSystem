using System.Data;
using System.Data.SqlClient;
using Dapper;
using LibraryManagementSystem.Modles;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly string _connectionString;

        public TransactionRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Transactions>> GetAllTransactionsAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Flag", "SE");

                return await connection.QueryAsync<Transactions>(
                    "SP_Transactions",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<Transactions> GetTransactionByIdAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Flag", "SE");
                parameters.Add("@TransactionId", id);

                return await connection.QueryFirstOrDefaultAsync<Transactions>(
                    "SP_Transactions",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> AddTransactionAsync(Transactions transaction)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Flag", "I");
                parameters.Add("@StudentId", transaction.StudentId);
                parameters.Add("@UserId", transaction.UserId);
                parameters.Add("@BookId", transaction.BookId);
                parameters.Add("@TransactionType", transaction.TransactionType);
                parameters.Add("@Date", transaction.Date);

                return await connection.ExecuteScalarAsync<int>(
                    "SP_Transactions",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<bool> UpdateTransactionAsync(Transactions transaction)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Flag", "U");
                parameters.Add("@TransactionId", transaction.TransactionId);
                parameters.Add("@StudentId", transaction.StudentId);
                parameters.Add("@UserId", transaction.UserId);
                parameters.Add("@BookId", transaction.BookId);
                parameters.Add("@TransactionType", transaction.TransactionType);
                parameters.Add("@Date", transaction.Date);

                var rowsAffected = await connection.ExecuteAsync(
                    "SP_Transactions",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return rowsAffected > 0;
            }
        }

        public async Task<bool> DeleteTransactionAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Flag", "D");
                parameters.Add("@TransactionId", id);

                var rowsAffected = await connection.ExecuteAsync(
                    "SP_Transactions",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return rowsAffected > 0;
            }
        }
    }
}
