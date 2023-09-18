using DBContextApp.BLL.Models;
using Microsoft.EntityFrameworkCore;

namespace DBContextApp.DAL.Repositories
{
    public class BookRepository : EFBaseRepository<Book>
    {
        DbContext _context;
        DbSet<Book> _dbSet;

        public BookRepository(DbContext context) : base(context)
        {
            _context = context;
            _dbSet = context.Set<Book>();
        }
    }
}
