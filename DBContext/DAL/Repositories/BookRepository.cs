using DBContextApp.BLL.Models;
using Microsoft.EntityFrameworkCore;

namespace DBContextApp.DAL.Repositories
{
    public class BookRepository
    {
        public User FindById(int userId)
        {
            using (var db = new DBContextApp.DAL.AppContext())
            {
                return db.Users.FirstOrDefault(u => u.Id == userId);
            }
        }

        public List<User> FindAll()
        {
            using (var db = new DBContextApp.DAL.AppContext())
            {
                return db.Users.ToList();
            }
        }

        public void Add(User user)
        {
            using (var db = new DBContextApp.DAL.AppContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public void Remove(User user)
        {
            using (var db = new DBContextApp.DAL.AppContext())
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }
    }
}
