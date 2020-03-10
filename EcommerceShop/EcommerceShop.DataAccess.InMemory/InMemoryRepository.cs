using EcommerceShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.DataAccess.InMemory
{
    public class InMemoryRepository<T> where T : BaseEntity
    {
        ObjectCache cache = MemoryCache.Default;
        List<T> items;
        string className;

        public InMemoryRepository()
        {
            className = typeof(T).Name;
            items = cache[className] as List<T>;

            if (items == null)
            {
                items = new List<T>();
            }
        }


        public void Commit()
        {
            cache[className] = items;
        }

        public void Insert(T t)
        {
            items.Add(t);
        }

        public void Update(T t)
        {
            T toUpdate = items.Find(p => p.Id == t.Id);

            if (toUpdate == null)
            {
                throw new Exception(className + " Not found");
            }
            else
            {
                toUpdate = t;
            }
        }

        public T Find(string Id)
        {
            T itemToFind = items.Find(p => p.Id == Id);

            if (itemToFind == null)
            {
                throw new Exception(className + " Not found");
            }
            else
            {
                return itemToFind;
            }
        }

        public IQueryable<T> Collection()
        {
            return items.AsQueryable();
        }

        public void Delete(string Id)
        {
            T itemToDelete = items.Find(p => p.Id == Id);

            if (itemToDelete == null)
            {
                throw new Exception(className + " Not found");
            }
            else
            {
                items.Remove(itemToDelete);
            }
        }
    }
}
