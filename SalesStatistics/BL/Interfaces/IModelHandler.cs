using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IModelHandler<K>
        where K : class
    {
        void AddToDb(K item);
        void UpdateInDb(K item);
        void RemoveFromDb(K item);
        K FindInDb(int id);
        IList<K> GetAll(Func<K, bool> predicate);
    }
}
