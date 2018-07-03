using System.Collections.Generic;
using Crayons.Api.Domain.Models;

namespace Crayons.Api.Domain.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseModel
    {
        void Add(T entity);
        IList<T> GetAll();
        T GetById(int id);
    }
}