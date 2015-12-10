using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDataRepository<T>
        where T : class
    {
        void Add(T item);
        void Update(T item);
        void Remove(T item);
        T FindById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAny(Func<T, bool> predicate);
    }
}
