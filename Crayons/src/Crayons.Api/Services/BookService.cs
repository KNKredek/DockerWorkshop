using System.Collections.Generic;
using Crayons.Api.Domain.Models;
using Crayons.Api.Domain.Repositories.Interfaces;
using Crayons.Api.Services.Interfaces;

namespace Crayons.Api.Services
{
    public class BookService : IBookService
    {
        private IRepository<Book> _bookRepository;
        public BookService(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public void Add(Book book)
        {
            _bookRepository.Add(book);
        }

        public IList<Book> GetAll()
        {
            return _bookRepository.GetAll();
        }

        public Book GetById(int id)
        {
            return _bookRepository.GetById(id);
        }
    }
}