using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSite.Repositories.Generic
{
    public interface IRepository<T, in K> where T : class
    {
        void Add(T entity);
        T Get(K id);
        IEnumerable<T> Get();
        void Remove(T entity);
    }
}