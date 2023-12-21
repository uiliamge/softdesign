using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class BooksDbContext : DbContext
    {
        public virtual DbSet<Book> Books { get; set; }
    }
}
