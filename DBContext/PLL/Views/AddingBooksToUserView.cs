using DBContextApp.BLL.Models;
using DBContextApp.DAL.Repositories;

namespace DBContextApp.PLL.Views
{
    public class AddingBooksToUserView
    {
        UserRepository userRepository;
        BookRepository bookRepository;
        public AddingBooksToUserView(UserRepository userRepository, BookRepository bookRepository)
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

            Console.WriteLine("Список книг, доступных для добавления:");

            foreach (var book in bookRepository.FindAll())
            {
                Console.WriteLine($"{book.Id} {book.Name} {book.Author} {book.PublicationDate} {book.Genre}");
            }
            Console.WriteLine();

            Console.WriteLine("Ввдеите Id книги, которую хотите выдать пользователю:");

            int bookId = int.Parse(Console.ReadLine());

            var addingBook = bookRepository.FindById(bookId);

            user.Books.Add(addingBook);

            Console.WriteLine("Книга успешно добавлена в список книг пользователя.");

            Console.WriteLine("Список книг пользователя:");

            foreach (var book in user.Books)
            {
                Console.WriteLine($"{book.Id} {book.Name} {book.Author} {book.PublicationDate} {book.Genre}");
            }
            Console.WriteLine();
        }
    }
}
