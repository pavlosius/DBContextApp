using DBContextApp.BLL.Models;
using Microsoft.EntityFrameworkCore;

namespace DBContextApp.DAL.Repositories
{
    public class UserRepository : EFBaseRepository<User>
    {
        public UserRepository(DbContext context) : base(context) {}

        public void Update(User user)
        {
            _dbSet.Update(user);
        }

        public override User FindById(int userId)
        {
            return _dbSet.Include(u => u.Books).FirstOrDefault(u => u.Id == userId);
        }

        public int CountOfBooksRecievedByUser(User user)
        {
            return user.Books.Count();
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
}
