using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.AbstractRepository
{
    public abstract class DataRepository<T, K> : IDataRepository<T>
        where T : class, IEquatable<T>
        where K : class
    {
        protected abstract K ConvertToEntity(T item);
        protected abstract T ConvertToObject(K item);

        public virtual void Add(T item)
        {
            using (var context = new EntityModels.SalesDataBaseEntities())
            {
                context.Entry(ConvertToEntity(item)).State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();
            }
        }

        public virtual void Update(T item)
        {
            using (var context = new EntityModels.SalesDataBaseEntities())
            {
                context.Entry(ConvertToEntity(item)).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public virtual void Remove(T item)
        {
            using (var context = new EntityModels.SalesDataBaseEntities())
            {
                context.Entry(ConvertToEntity(item)).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public T FindById(int id)
        {
            T item;
            using (var context = new EntityModels.SalesDataBaseEntities())
            {
                K dbItem = context.Set<K>().Find(id);
                item = ConvertToObject(dbItem);
            }
            return item;
        }

        public virtual IEnumerable<T> GetAll()
        {
            IEnumerable<T> list;
            using (var context = new EntityModels.SalesDataBaseEntities())
            {
                list = context
                    .Set<K>()
                    .AsNoTracking()
                    .ToList()
                    .Select(x => ConvertToObject(x))
                    .ToList();
            }
            return list ?? new List<T>();
        }

        public virtual bool IsExists(T item)
        {
            T dbItem;
            using (var context = new EntityModels.SalesDataBaseEntities())
            {
                var entityItem = context
                    .Set<K>()
                    .ToList()
                    .Select(x => ConvertToObject(x))
                    .FirstOrDefault(x => x.Equals(item));
                dbItem = entityItem;
            }
            return dbItem == null ? false : true;
        }
    }
}
