using Dapper;
using LibraryManagementSystem.Modles;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace LibraryManagementSystem.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task AddUserAsync(Users user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Flag", "S"); // Flag for Sign-Up
                parameters.Add("@Username", user.Username);
                parameters.Add("@Password", user.Password);
                parameters.Add("@Email", user.Email);
                parameters.Add("@Role", user.Role);

                await connection.ExecuteAsync("sp_UserOperations", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<Users> GetUserByUsernameAsync(string username)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Flag", "L"); // Flag for Login
                parameters.Add("@Username", username);

                return await connection.QueryFirstOrDefaultAsync<Users>(
                    "sp_UserOperations",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
