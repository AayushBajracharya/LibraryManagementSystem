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
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Email
{
    public class DailyEmailService : IHostedService, IDisposable
    {
        private readonly IConfiguration _configuration;
        private readonly Email _emailService;
        private readonly ILogger<DailyEmailService> _logger;
        private Timer _timer;

        public DailyEmailService(IConfiguration configuration, Email emailService, ILogger<DailyEmailService> logger)
        {
            _configuration = configuration;
            _emailService = emailService;
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Daily Email Service is starting.");

            // Set the timer to check for overdue books every 5 minutes
            _timer = new Timer(SendEmails, null, TimeSpan.Zero, TimeSpan.FromHours(2));

            return Task.CompletedTask;
        }


        private async void SendEmails(object state)
        {
            _logger.LogInformation("Starting to send emails...");

            try
            {
                // Fetch overdue users
                var overdueUsers = await GetOverdueBooksAsync();

                foreach (var user in overdueUsers)
                {
                    var subject = "Overdue Book Notification";
                    var body = $"Dear {user.Name},<br/>" +
                               $"The book titled '<b>{user.BookTitle}</b>' is overdue. Please return it as soon as possible.";

                    await _emailService.SendEmailAsync(user.Email, subject, body);
                }

                _logger.LogInformation("Emails sent successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while sending emails.");
            }
        }

        private async Task<IEnumerable<EmailData>> GetOverdueBooksAsync()
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                const string storedProcedure = "usp_GetOverdueBooks";

                // Execute the stored procedure using Dapper
                return await connection.QueryAsync<EmailData>(
                    storedProcedure,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Daily Email Service is stopping.");
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose() => _timer?.Dispose();
    }
}
