using DBContextApp.BLL.Models;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace DBContextApp.DAL.Repositories
{
    public class BookRepository : EFBaseRepository<Book>
    {
        //DbContext _context;
        //DbSet<Book> _dbSet;

        public BookRepository(DbContext context) : base(context)
        {
            //_context = context;
            //_dbSet = context.Set<Book>();
        }
        public override Book FindById(int bookId)
        {
            //return _dbSet.Include(b => b.Users).Where(b => b.Id == bookId).First();
            return _dbSet.Include(b => b.Users).FirstOrDefault(b => b.Id == bookId);
        }

        public List<Book> Find(String genre, DateTime start, DateTime end)
        {
            return _dbSet.Where(book => book.Genre.ToUpper() == genre.ToUpper() && book.PublicationDate > start && book.PublicationDate < end).ToList();
        }

        public int CountByGenre(String genre)
        {
            return _dbSet.Where(book => book.Genre.ToUpper() == genre.ToUpper()).ToList().Count;
        }

        public int CountByAuthor(String author)
        {
            return _dbSet.Where(book => book.Author.ToUpper() == author.ToUpper()).ToList().Count;
        }

        public bool CheckBookExistance(String name, String author)
        {
            return _dbSet.Any(book => book.Name.ToUpper() == name.ToUpper() && book.Author.ToUpper() == author.ToUpper());
        }
        public bool CheckBookRecievedByUser(Book book, User user)
        {
            return user.Books.Any(b => b.Id == book.Id);
        }
        public Book GetLastPublishedBook()
        {
            return _dbSet.OrderByDescending(b=>b.PublicationDate).FirstOrDefault();
        }

        public List<Book> GetAllOrderedByName()
        {
            return _dbSet.OrderBy(b=>b.Name).ToList();
        }
        public List<Book> GetAllOrderedByDescendingPublicationDate()
        {
            return _dbSet.OrderByDescending(b => b.PublicationDate).ToList();
        }
    }
}
