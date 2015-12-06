using BL.Interfaces;
using DAL.AbstractRepository;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Handlers
{
    public abstract class ModelHandler<T, K> : IModelHandler<T>
        where K : class
        where T : class
    {
        protected abstract IDataRepository<K> _repository { get; }

        protected abstract T EntityToModel(K item);
        protected abstract K ModelToEntity(T item);

        public void AddToDb(T item)
        {
            _repository.Add(ModelToEntity(item));
        }

        public void UpdateInDb(T item)
        {
            _repository.Update(ModelToEntity(item));
        }

        public void RemoveFromDb(T item)
        {
            _repository.Remove(ModelToEntity(item));
        }

        public T FindInDb(int id)
        {
            var entityItem = _repository.FindById(id);
            return entityItem == null ? null : EntityToModel(entityItem);
        }

        public IList<T> GetAll(Func<T, bool> predicate)
        {
            return new List<T>(_repository.GetAll(x => true).Select(x => EntityToModel(x)).Where(x => predicate(x)));
        }
    }
}
