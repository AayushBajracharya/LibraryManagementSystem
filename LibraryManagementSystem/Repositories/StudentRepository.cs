using Dapper;
using LibraryManagementSystem.Modles;
using LibraryManagementSystem.Repositories;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem.Infrastructure
{
    public class StudentRepository : IStudentRepository
    {
        private readonly string _connectionString;

        public StudentRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Students>> GetAllStudentsAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Flag", "SE");

                return await connection.QueryAsync<Students>(
                    "SP_Students",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<Students> GetStudentByIdAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Flag", "SE");
                parameters.Add("@StudentId", id);

                return await connection.QueryFirstOrDefaultAsync<Students>(
                    "SP_Students",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> AddStudentAsync(Students student)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Flag", "I");
                parameters.Add("@Name", student.Name);
                parameters.Add("@Email", student.Email);
                parameters.Add("@ContactNumber", student.ContactNumber);
                parameters.Add("@Department", student.Department);

                // Retrieve the new Student ID
                return await connection.ExecuteScalarAsync<int>(
                    "SP_Students",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }


        public async Task<bool> UpdateStudentAsync(Students student)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Flag", "U");
                parameters.Add("@StudentId", student.StudentId);
                parameters.Add("@Name", student.Name);
                parameters.Add("@Email", student.Email);
                parameters.Add("@ContactNumber", student.ContactNumber);
                parameters.Add("@Department", student.Department);

                var rowsAffected = await connection.ExecuteAsync(
                    "SP_Students",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return rowsAffected > 0;
            }
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Flag", "D");
                parameters.Add("@StudentId", id);

                var rowsAffected = await connection.ExecuteAsync(
                    "SP_Students",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return rowsAffected > 0;
            }
        }
    }
}
