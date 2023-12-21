using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class BooksDbContext : DbContext
    {
        public BooksDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }
    }
}
