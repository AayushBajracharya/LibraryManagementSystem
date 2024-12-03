using LibraryManagementSystem.Modles;

namespace Infrastructure.Repositories
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Authors>> GetAllAuthorsAsync();
        Task<Authors> GetAuthorByIdAsync(int id);
        Task<int> AddAuthorAsync(Authors author);
        Task<bool> UpdateAuthorAsync(Authors author);
        Task<bool> DeleteAuthorAsync(int id);
    }
}
