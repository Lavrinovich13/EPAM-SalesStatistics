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

        protected abstract T ConvertToBlModel(K item);
        protected abstract K ConvertToDalModel(T item);

        public void AddToDb(T item)
        {
            if (!IsExists(item))
            {
                _repository.Add(ConvertToDalModel(item));
            }
        }

        public void UpdateInDb(T item)
        {
            if (!IsExists(item))
            {
                _repository.Update(ConvertToDalModel(item));
            }
        }

        public void RemoveFromDb(T item)
        {
            _repository.Remove(ConvertToDalModel(item));
        }

        public T FindInDb(int id)
        {
            var entityItem = _repository.FindById(id);
            return entityItem == null ? null : ConvertToBlModel(entityItem);
        }

        public IList<T> GetAll()
        {
            return new List<T>(_repository
                .GetAll()
                .Select(x => ConvertToBlModel(x)));
        }

        public bool IsExists(T item)
        {
            return _repository.IsExists(ConvertToDalModel(item));
        }
    }
}
