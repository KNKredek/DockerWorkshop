using System.Collections.Generic;
using System.Linq;
using Crayons.Api.Domain.Models;
using Crayons.Api.Domain.Repositories.Interfaces;

namespace Crayons.Api.Domain.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseModel
    {
        protected readonly LibraryDbContext _context;
        public BaseRepository(LibraryDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }
        public virtual void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public virtual IList<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public virtual T GetById(int id)
        {
            return _context.Set<T>().Where(x=>x.Id.Equals(id)).FirstOrDefault();
        }
    }
}