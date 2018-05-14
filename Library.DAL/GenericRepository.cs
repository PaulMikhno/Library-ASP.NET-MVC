using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using Library.Entities.Interfaces;

namespace Library.DAL
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private DbContext context;//may be static?
        DbSet<TEntity> dbSet;


        public GenericRepository(DbContext dbContext)
        {
            this.context = dbContext;
            dbSet = context.Set<TEntity>();
        }
        
        public TEntity Get(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<TEntity> Get()
        {
            return dbSet.ToList();
        }

        public void Create(TEntity item)
        {
            dbSet.Add(item);
            context.SaveChanges();
        }

        public void Update(TEntity item)
        {
            context.Entry(item).State = EntityState.Modified;
            context.SaveChanges();//something wrong 
        }

        public void Remove(int id)
        {
            var item = dbSet.Find(id);
            dbSet.Remove(item);
            context.SaveChanges();
        }

       public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
       {
            return dbSet.Where(predicate).ToList();
       }

    }

}

