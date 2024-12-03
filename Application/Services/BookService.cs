using Infrastructure.Repositories;
using LibraryManagementSystem.Modles;

namespace Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<Books>> GetAllBooksAsync()
        {
            return await _bookRepository.GetAllBooksAsync();
        }

        public async Task<Books> GetBookByIdAsync(int id)
        {
            return await _bookRepository.GetBookByIdAsync(id);
        }

        public async Task<int> AddBookAsync(Books book)
        {
            return await _bookRepository.AddBookAsync(book);
        }

        public async Task<bool> UpdateBookAsync(Books book)
        {
            return await _bookRepository.UpdateBookAsync(book);
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            return await _bookRepository.DeleteBookAsync(id);
        }
    }
}
