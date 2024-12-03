using System;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using LibraryManagementSystem.Modles;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly string _connectionString;

        public BookRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Books>> GetAllBooksAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Flag", "SE");

                return await connection.QueryAsync<Books>(
                    "SP_Books",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<Books> GetBookByIdAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Flag", "SE");
                parameters.Add("@BookId", id);

                return await connection.QueryFirstOrDefaultAsync<Books>(
                    "SP_Books",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> AddBookAsync(Books book)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Flag", "I");
                parameters.Add("@Title", book.Title);
                parameters.Add("@AuthorId", book.AuthorId);
                parameters.Add("@Genre", book.Genre);
                parameters.Add("@ISBN", book.ISBN);
                parameters.Add("@Quantity", book.Quantity);

                return await connection.ExecuteScalarAsync<int>(
                    "SP_Books",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<bool> UpdateBookAsync(Books book)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Flag", "U");
                parameters.Add("@BookId", book.BookId);
                parameters.Add("@Title", book.Title);
                parameters.Add("@AuthorId", book.AuthorId);
                parameters.Add("@Genre", book.Genre);
                parameters.Add("@ISBN", book.ISBN);
                parameters.Add("@Quantity", book.Quantity);

                var rowsAffected = await connection.ExecuteAsync(
                    "SP_Books",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return rowsAffected > 0;
            }
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Flag", "D");
                parameters.Add("@BookId", id);

                var rowsAffected = await connection.ExecuteAsync(
                    "SP_Books",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return rowsAffected > 0;
            }
        }
    }
}
