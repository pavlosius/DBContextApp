using DBContextApp.BLL.Models;
using DBContextApp.DAL.Configurations;
using Microsoft.EntityFrameworkCore;

namespace DBContextApp.DAL
{
    public class AppContext : DbContext
    {
        // Объекты таблицы Users
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public AppContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString.MsSqlConnection);
        }
    }
}
