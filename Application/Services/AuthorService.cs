using Infrastructure.Repositories;
using LibraryManagementSystem.Modles;

namespace Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<IEnumerable<Authors>> GetAllAuthorsAsync()
        {
            return await _authorRepository.GetAllAuthorsAsync();
        }

        public async Task<Authors> GetAuthorByIdAsync(int id)
        {
            return await _authorRepository.GetAuthorByIdAsync(id);
        }

        public async Task<int> AddAuthorAsync(Authors author)
        {
            return await _authorRepository.AddAuthorAsync(author);
        }

        public async Task<bool> UpdateAuthorAsync(Authors author)
        {
            return await _authorRepository.UpdateAuthorAsync(author);
        }

        public async Task<bool> DeleteAuthorAsync(int id)
        {
            return await _authorRepository.DeleteAuthorAsync(id);
        }
    }
}
