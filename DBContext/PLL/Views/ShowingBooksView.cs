using DBContextApp.BLL.Models;
using DBContextApp.DAL.Repositories;

namespace DBContextApp.PLL.Views
{
    public class ShowingBooksView
    {
        BookRepository bookRepository;
        public ShowingBooksView(BookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public void Show(List<Book> books)
        {
            Console.WriteLine("Список книг:");
            Console.WriteLine("Id Название Автор Дата_публикации Жанр");
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Id} {book.Name} {book.Author} {book.PublicationDate.ToString("dd/MM/yyyy")} {book.Genre}");
            }
            Console.WriteLine();
        }
    }
}
