using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Entities.Interfaces
{

    public interface IRepository<TEntity>  where TEntity : class
    {
        void Create(TEntity item);
        IEnumerable<TEntity> Get();
        TEntity Get(int id);
        void Remove(int id);
        void Update(TEntity item);
    }
}
