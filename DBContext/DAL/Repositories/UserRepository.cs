using DBContextApp.BLL.Models;
using Microsoft.EntityFrameworkCore;

namespace DBContextApp.DAL.Repositories
{
    public class UserRepository : EFBaseRepository<User>
    {

        DbContext _context;
        DbSet<User> _dbSet;

        public UserRepository(DbContext context) : base(context)
        {
            //_context = context;
            //_dbSet = context.Set<User>();
        }

        void Update(User userEntity)
        {

        }






        //    public UserRepository(DbContext context)
        //{
        //    _context = context;
        //    _dbSet = context.Set<User>();
        //}


        //public User FindById(int userId)
        //{
        //    using (var db = new DBContextApp.DAL.AppContext())
        //    {
        //        return db.Users.FirstOrDefault(u => u.Id == userId);
        //    }
        //}

        //public List<User> FindAll()
        //{
        //    using (var db = new DBContextApp.DAL.AppContext())
        //    {
        //        return db.Users.ToList();
        //    }
        //}

        //public void Add(User user)
        //{
        //    using (var db = new DBContextApp.DAL.AppContext())
        //    {
        //        db.Users.Add(user);
        //        db.SaveChanges();
        //    }
        //}

        //public void Remove(User user)
        //{
        //    using (var db = new DBContextApp.DAL.AppContext())
        //    {
        //        db.Users.Remove(user);
        //        db.SaveChanges();
        //    }
        //}
    }

    public interface IUserRepository
    {
        int Update(User userEntity);
        int DeleteById(int id);
    }
}
