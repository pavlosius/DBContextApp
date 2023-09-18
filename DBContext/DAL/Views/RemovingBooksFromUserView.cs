using DBContextApp.BLL.Services;
using DBContextApp.BLL.Models;
using DBContextApp.DAL.Repositories;
using DBContextApp.BLL.Exceptions;

namespace DBContextApp.PLL.Views
{
    public class RemovingBooksFromUserView
    {
        UserRepository userRepository;
        BookRepository bookRepository;
        public RemovingBooksFromUserView(UserRepository userRepository, BookRepository bookRepository)
        {
            this.userRepository = userRepository;
            this.bookRepository = bookRepository;
        }
        public void Show(User user)
        {
            Console.WriteLine("Список книг пользователя:");

            foreach (var book in user.Books)
            {
                Console.WriteLine($"{book.Id} {book.Name} {book.Author} {book.PublicationDate} {book.Genre}");
            }

            Console.WriteLine("Ввдеите Id книги, которую хотите выдать пользователю:");

            int bookId = int.Parse(Console.ReadLine());

            var removingBook = bookRepository.FindById(bookId);

            user.Books.Remove(removingBook);

            Console.WriteLine("Книга успешно удалена из списока книг пользователя.");
            
            Console.WriteLine("Список книг пользователя:");

            foreach (var book in user.Books)
            {
                Console.WriteLine($"{book.Id} {book.Name} {book.Author} {book.PublicationDate} {book.Genre}");
            }
        }
    }
}
