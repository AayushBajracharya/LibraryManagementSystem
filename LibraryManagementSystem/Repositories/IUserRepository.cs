using LibraryManagementSystem.Modles;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Repositories
{
    public interface IUserRepository
    {
        Task AddUserAsync(Users user);
        Task<Users> GetUserByUsernameAsync(string username);
    }
}
