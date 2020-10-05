using System.Collections.Generic;
using GimcheonLibrary.DataAccess.Models;

namespace GimcheonLibrary.DataAccess.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Add(T item);
        void Remove(int id);
        void Update(T item);
        T FindById(int id);
        IEnumerable<T> FindAll();
    }
}
