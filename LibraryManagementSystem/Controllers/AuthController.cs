using LibraryManagementSystem.Modles;
using LibraryManagementSystem.Repositories;
using LibraryManagementSystem.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using LibraryManagementSystem.Utilities;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtTokenHelper _jwtHelper;

        public AuthController(IUserRepository userRepository, JwtTokenHelper jwtHelper)
        {
            _userRepository = userRepository;
            _jwtHelper = jwtHelper;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] Users users)
        {
            users.Password = HashPassword(users.Password);
            await _userRepository.AddUserAsync(users);

            return Ok(new { message = "User registered successfully" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginRequest)
        {
            var user = await _userRepository.GetUserByUsernameAsync(loginRequest.Username);

            if (user == null || !VerifyPassword(loginRequest.Password, user.Password))
            {
                return Unauthorized(new { message = "Invalid username or password" });
            }

            var token = _jwtHelper.GenerateToken(user);

            return Ok(new { token });
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        private bool VerifyPassword(string enteredPassword, string storedHash)
        {
            return HashPassword(enteredPassword) == storedHash;
        }
    }
}
