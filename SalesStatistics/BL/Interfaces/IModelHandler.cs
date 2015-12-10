using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IModelHandler<T>
        where T : class
    {
        void AddToDb(T item);
        void UpdateInDb(T item);
        void RemoveFromDb(T item);
        T FindInDb(int id);
        IList<T> GetAll();
        IList<T> GetAny(Func<T, bool> predicate);
    }
}
