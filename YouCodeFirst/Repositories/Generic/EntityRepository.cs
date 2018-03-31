using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebSite.Repositories.Generic
{
    public abstract class EntityRepository<E, T, K> : Repository<T, K>
        where E : DbContext
        where T : class
    {
        protected E _context = null;

        public EntityRepository(E context)
        {
            if (context == null) throw new ArgumentNullException("context");

            _context = context;
        }

        public override void Add(T entity)
        {
            _context.Set<T>().
                Add(entity);
        }

        public override T Get(K id)
        {
            return _context.Set<T>().
                Find(id);
        }

        public override IEnumerable<T> Get()
        {
            return _context.Set<T>().
                ToList();
        }

        public override void Remove(T entity)
        {
            _context.Set<T>().
                Remove(entity);
        }
    }

}