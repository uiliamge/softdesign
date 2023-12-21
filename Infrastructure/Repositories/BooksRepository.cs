using Domain;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        public readonly BooksDbContext _dbContext;

        public BooksRepository(BooksDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Book> AddAsync(Book entity)
        {
            await _dbContext.Books.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(Book entity)
        {
            _dbContext.Books.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<Book>> GetAllAsync()
        {
            return await _dbContext.Books.AsNoTracking().ToListAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _dbContext.Books.FindAsync(id);
        }

        public async Task UpdateAsync(Book entity)
        {
            _dbContext.Books.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
