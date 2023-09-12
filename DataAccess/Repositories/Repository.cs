using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext pContext)
        {
            Context = pContext;
        }

        public void Add(TEntity pEntity)
        {
            Context.Set<TEntity>().Add(pEntity);
        }

        public int Count()
        {
            return Context.Set<TEntity>().Count();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public TEntity GetById(int pId)
        {
            return Context.Set<TEntity>().Find(pId);
        }

        public void Remove(TEntity pEntity)
        {
            Context.Set<TEntity>().Remove(pEntity);
        }
    }
}
