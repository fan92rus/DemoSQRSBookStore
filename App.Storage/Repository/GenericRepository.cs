using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Models;

namespace App.Storage.Repository
{
    internal interface IGenericRepository<T> where T : Entity
    {
        int Add(T item);
        IEnumerable<int> AddSet(IEnumerable<T> items);
        void Remove(T item);
        void RemoveRange(IEnumerable<T> entities);
        void Update(T item);
        IEnumerable<T> Get(Func<T, bool> predicate);
        T GetById(int id);
    }

    public class GenericRepository<T> : IGenericRepository<T> where T : Entity
    {
        private DbContext Context { get; }
        private DbSet<T> Collection { get; }

        public GenericRepository(DbContext store)
        {
            this.Collection = store.Set<T>();
            this.Context = store;
        }

        public int Add(T item)
        {
            Collection.Add(item);
            Context.SaveChanges();
            return item.Id;
        }
        public IEnumerable<int> AddSet(IEnumerable<T> items)
        {
            if (items != null && items.Any())
            {
                Collection.AddRange(items);
                Context.SaveChanges();
                return items.Select(x => x.Id);
            }
            return new int[] { };
        }
        public void Remove(T item)
        {
            Collection.Remove(item);
            Context.SaveChanges();
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            Collection.RemoveRange(entities);
            Context.SaveChanges();
        }
        public void Update(T item)
        {
            Context.Entry(item).State = EntityState.Modified;
            Context.SaveChanges();
        }
        public IEnumerable<T> Get(Func<T, bool> predicate)
        {
            return Collection.AsNoTracking().Where(predicate);
        }
        
        public T GetById(int id) => Collection.FirstOrDefault(x => x.Id == id);
    }
}
