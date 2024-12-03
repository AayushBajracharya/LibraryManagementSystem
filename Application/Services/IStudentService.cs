
using LibraryManagementSystem.Modles;

namespace LibraryManagementSystem.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Students>> GetAllStudentsAsync();
        Task<Students> GetStudentByIdAsync(int id);
        Task<int> AddStudentAsync(Students student);
        Task<bool> UpdateStudentAsync(Students student);
        Task<bool> DeleteStudentAsync(int id);
    }
}
