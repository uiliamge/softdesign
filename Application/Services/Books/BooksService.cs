using Domain;
using Domain.Interfaces;
using Shared.DTOs.Books;

namespace Application.Services.Books
{
    public class BooksService : IBooksService
    {
        public readonly IBooksRepository _repository;

        public BooksService(IBooksRepository repository)
        {
            _repository = repository;
        }

        public async Task<Book> AddAsync(AddBookDTO dto)
        {
            var book = new Book
            {
                Title = dto.Title,
                Author = dto.Author,
                ReleaseYear = dto.ReleaseYear,
            };

            return await _repository.AddAsync(book);
        }

        public async Task DeleteAsync(int id)
        {
            var book = await _repository.GetByIdAsync(id);
            if (book != null)
            {
                await _repository.DeleteAsync(book);
            }
        }

        public async Task<IReadOnlyList<Book>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(BookDTO dto)
        {
            var book = await _repository.GetByIdAsync(dto.Id);

            book.Author = dto.Author != book.Author ? dto.Author : book.Author;
            book.Title = dto.Title != book.Title ? dto.Title : book.Title;
            book.ReleaseYear = dto.ReleaseYear != book.ReleaseYear ? dto.ReleaseYear : book.ReleaseYear;

            if (book != null)
            {
                await _repository.UpdateAsync(book);
            }
        }
    }
}
