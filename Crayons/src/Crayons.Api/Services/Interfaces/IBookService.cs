using System.Collections.Generic;
using Crayons.Api.Domain.Models;

namespace Crayons.Api.Services.Interfaces
{
    public interface IBookService
    {
        IList<Book> GetAll();
        Book GetById(int id);
        void Add(Book book);
    }
}