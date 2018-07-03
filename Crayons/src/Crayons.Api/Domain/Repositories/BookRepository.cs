using System.Collections.Generic;
using System.Linq;
using Crayons.Api.Domain.Models;
using Crayons.Api.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Crayons.Api.Domain.Repositories
{
    public class BookRepository : BaseRepository<Book>, IRepository<Book>
    {
        public BookRepository(LibraryDbContext context) : base(context)
        {
        }

        public override Book GetById(int id)
        {
            return _context.Books.Include(x=>x.Author).Where(x=>x.Id.Equals(id)).FirstOrDefault();
        }

        public override IList<Book> GetAll()
        {
            return _context.Books.Include(x=>x.Author).ToList();
        }
    }
}