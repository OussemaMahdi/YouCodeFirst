using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSite.Repositories.Generic
{
    public abstract class Repository<T, K> : IRepository<T, K>
       where T : class
    {
        public abstract void Add(T entity);
        public abstract T Get(K id);
        public abstract IEnumerable<T> Get();
        public abstract void Remove(T entity);
    }
}