using Crayons.Api.Domain.Configurations;
using Crayons.Api.Domain.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace Crayons.Api.Domain
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
        }
    }
}