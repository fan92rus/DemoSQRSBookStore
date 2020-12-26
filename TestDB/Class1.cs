using System;
using Microsoft.EntityFrameworkCore;

namespace TestDB
{
    public class AppContext : DbContext
    {
        public AppContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=booksDB;Username=postgres;Password=1");

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
    }

    public class Author
    {
        public int id { get; set; }
        public string Name { get; set; }
    }

    public class Book
    {
        public int id { get; set; }
        public string Title { get; set; }
    }
}
