using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Domain.Entities.Modles;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Repositories
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly string _connectionString;

        public DashboardRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<Dashboard> GetDashboardDataAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Flag", "GetDashboardData");

                var dashboard = await connection.QueryFirstOrDefaultAsync<Dashboard>(
                    "usp_GetDashboardData",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return dashboard;
            }
        }

        public async Task<IEnumerable<OverdueBorrower>> GetOverdueBorrowersAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Flag", "GetOverdueBorrowers");

                return await connection.QueryAsync<OverdueBorrower>(
                    "usp_GetDashboardData",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
