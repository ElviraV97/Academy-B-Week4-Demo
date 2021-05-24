using System;
using System.Collections.Generic;
using System.Text;

namespace Week4.Core.Interfaces
{
    public interface IRepository<TEntity>
    {
        List<TEntity> Fetch();
        TEntity GetById(int id);
        bool Add(TEntity item);
        bool Update(TEntity item);
        bool Delete(TEntity item);
    }
}
