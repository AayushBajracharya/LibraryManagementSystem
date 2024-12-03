
using LibraryManagementSystem.Modles;

namespace LibraryManagementSystem.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Students>> GetAllStudentsAsync();
        Task<Students> GetStudentByIdAsync(int id);
        Task<int> AddStudentAsync(Students student);
        Task<bool> UpdateStudentAsync(Students student);
        Task<bool> DeleteStudentAsync(int id);
    }
}
