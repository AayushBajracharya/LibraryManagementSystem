using System.Data;
using System.Data.SqlClient;
using Dapper;
using LibraryManagementSystem.Modles;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly string _connectionString;

        public AuthorRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Authors>> GetAllAuthorsAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Flag", "SE");

                return await connection.QueryAsync<Authors>(
                    "SP_Authors",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<Authors> GetAuthorByIdAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Flag", "SE");
                parameters.Add("@AuthorID", id);

                return await connection.QueryFirstOrDefaultAsync<Authors>(
                    "SP_Authors",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> AddAuthorAsync(Authors author)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Flag", "I");
                parameters.Add("@Name", author.Name);
                parameters.Add("@Bio", author.Bio);

                return await connection.ExecuteScalarAsync<int>(
                    "SP_Authors",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<bool> UpdateAuthorAsync(Authors author)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Flag", "U");
                parameters.Add("@AuthorID", author.AuthorID);
                parameters.Add("@Name", author.Name);
                parameters.Add("@Bio", author.Bio);

                var rowsAffected = await connection.ExecuteAsync(
                    "SP_Authors",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return rowsAffected > 0;
            }
        }

        public async Task<bool> DeleteAuthorAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Flag", "D");
                parameters.Add("@AuthorID", id);

                var rowsAffected = await connection.ExecuteAsync(
                    "SP_Authors",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return rowsAffected > 0;
            }
        }
    }
}
