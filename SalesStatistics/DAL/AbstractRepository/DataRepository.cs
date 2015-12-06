using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.AbstractRepository
{
    public abstract class DataRepository<T> : IDataRepository<T>
        where T : class
    {
        public virtual void Add(T item)
        {
            using (var context = new EntityModels.SalesDataBaseEntities())
            {
                context.Entry(item).State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();
            }
        }

        public virtual void Update(T item)
        {
            using (var context = new EntityModels.SalesDataBaseEntities())
            {
                context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public virtual void Remove(T item)
        {
            using (var context = new EntityModels.SalesDataBaseEntities())
            {
                context.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public virtual IEnumerable<T> GetAll(Func<T, bool> predicate)
        {
            IEnumerable<T> list;
            using (var context = new EntityModels.SalesDataBaseEntities())
            {
                list = context
                    .Set<T>()
                    .AsNoTracking()
                    .Where(predicate)
                    .ToList();
            }
            return list ?? new List<T>();
        }

        public virtual T FindByFields(T item)
        {
            T dbItem;
            using (var context = new EntityModels.SalesDataBaseEntities())
            {
                var entityItem = context
                    .Set<T>()
                    .ToList()
                    .FirstOrDefault(x => x.Equals(item));
                dbItem = entityItem;
            }
            return dbItem;
        }


        public T FindById(int id)
        {
            T dbItem;
            using (var context = new EntityModels.SalesDataBaseEntities())
            {
                dbItem = context.Set<T>().Find(id);
            }
            return dbItem;
        }
    }
}
