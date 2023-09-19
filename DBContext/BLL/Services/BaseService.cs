using DBContextApp.DAL.Repositories;
using DBContextApp.BLL.Models;
using DBContextApp.BLL.Exceptions;
using System.Numerics;

namespace DBContextApp.BLL.Services
{
    public class BaseService<TEntity> : IEFBaseService<TEntity> where TEntity : class
    {
        EFBaseRepository<TEntity> entityRepository;

        public BaseService(DBContextApp.DAL.AppContext appContext)
        {
            entityRepository = new EFBaseRepository<TEntity>(appContext);
        }

        public TEntity FindById(int id)
        {
            var findUser = entityRepository.FindById(id);
            if (findUser is null) throw new ItemNotFoundException();

            return findUser;
        }

        public List<TEntity> FindAll()
        {
            return entityRepository.FindAll();
        }

        public void Add(TEntity newItem)
        {
            entityRepository.Add(newItem);
        }

        public void Remove(TEntity item)
        {
            entityRepository.Remove(item);
        }

        public void RemoveById(int itemId)
        {
            var findItem = FindById(itemId);
            if (findItem == null) throw new ItemNotFoundException();
            entityRepository.Remove(findItem);
        }
    }
}
