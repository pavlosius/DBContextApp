using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBContextApp.DAL.Repositories
{
    public interface IEFBaseRepository<TEntity> where TEntity : class
    {
        List<TEntity> FindAll();
        TEntity FindById(int id);
        void Add(TEntity item);
        void Update(TEntity item);
        void Remove(TEntity item);
    }
}
