using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardRepository _dashboardRepository;

        public DashboardController(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }

        [HttpGet("GetDashboardData")]
        public async Task<IActionResult> GetDashboardData()
        {
            var dashboardData = await _dashboardRepository.GetDashboardDataAsync();
            return Ok(dashboardData);
        }

        [HttpGet("GetOverdueBorrowers")]
        public async Task<IActionResult> GetOverdueBorrowers()
        {
            var overdueBorrowers = await _dashboardRepository.GetOverdueBorrowersAsync();
            return Ok(overdueBorrowers);
        }
    }
}
