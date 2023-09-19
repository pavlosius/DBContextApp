using DBContextApp.BLL.Models;
using Microsoft.EntityFrameworkCore;

namespace DBContextApp.DAL.Repositories
{
    public class UserRepository : EFBaseRepository<User>
    {
        public UserRepository(DbContext context) : base(context) {}

        public override User FindById(int userId)
        {
            return _dbSet.Include(u => u.Books).FirstOrDefault(u => u.Id == userId);
        }

        public int CountOfBooksRecievedByUser(User user)
        {
            return user.Books.Count();
        }
    }
}
