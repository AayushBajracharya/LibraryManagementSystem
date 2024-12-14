using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Modles;

namespace Infrastructure.Repositories
{
    public interface IDashboardRepository
    {
        Task<Dashboard> GetDashboardDataAsync();

        Task<IEnumerable<OverdueBorrower>> GetOverdueBorrowersAsync();
    }
}
