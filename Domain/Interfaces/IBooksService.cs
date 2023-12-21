using Shared.DTOs.Books;

namespace Domain.Interfaces
{
    public interface IBooksService
    {
        Task<IReadOnlyList<Book>> GetAllAsync();
        Task<Book> GetByIdAsync(int id);
        Task<Book> AddAsync(AddBookDTO dto);
        Task DeleteAsync(int id);
        Task UpdateAsync(BookDTO dto);
    }
}
