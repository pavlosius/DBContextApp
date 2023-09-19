using DBContextApp.BLL.Models;
using Microsoft.EntityFrameworkCore;


namespace DBContextApp.DAL.Repositories
{
    public class EFBaseRepository<TEntity> : IEFBaseRepository<TEntity> where TEntity : class
    {
        protected DbContext _context;
        protected DbSet<TEntity> _dbSet;

        public EFBaseRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public List<TEntity> FindAll()
        {
            return _dbSet.ToList();
        }
        public virtual TEntity FindById(int id)
        {
            return _dbSet.Find(id);
        }
        public void Add(TEntity item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }
        public void Remove(TEntity item)
        {
            _dbSet.Remove(item);
            _context.SaveChanges();
        }
    }
}
