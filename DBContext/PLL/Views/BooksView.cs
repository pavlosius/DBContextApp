using DBContextApp.BLL.Models;
using DBContextApp.BLL.Services;
using DBContextApp.DAL.Repositories;

namespace DBContextApp.PLL.Views
{
    public class BooksView
    {
        //UserService userService;
        //public BooksView(UserService userService)
        //{
        //    this.userService = userService;
        //}

        BookRepository bookRepository;
        UserRepository userRepository;

        public BooksView(BookRepository bookRepository, UserRepository userRepository)
        {
            this.bookRepository = bookRepository;
            this.userRepository = userRepository;
        }
        public void Show()
        {
            var books = bookRepository.FindAll();
            Program.showingBooksView.Show(books);

            //Console.WriteLine("Список книг в библиотеке:");
            //Console.WriteLine("Id Название Автор Дата_публикации Жанр");
            //foreach (var book in books)
            //{
            //    Console.WriteLine($"{book.Id} {book.Name} {book.Author} {book.PublicationDate.ToString("dd/MM/yy")} {book.Genre}");
            //}
            //Console.WriteLine();


            while (true)
            {
                Console.WriteLine("Добавление книги (нажмите 1)");
                Console.WriteLine("Удаление книги (нажмите 2)");
                Console.WriteLine("Изменение жанра книги (нажмите 3)");
                Console.WriteLine("Поиск книг определенного жанра и вышедших между определенными годами (нажмите 4)");
                Console.WriteLine("Количесвто книг определенного жанра (нажмите 5)");
                Console.WriteLine("Количесвто книг определенного автора (нажмите 6)");
                Console.WriteLine("Проверить, есть ли книга определенного автора и с определенным названием в библиотеке (нажмите 7)");
                Console.WriteLine("Проверить, есть ли определенная книга на руках у пользователя (нажмите 8)");
                Console.WriteLine("Получение последней вышедшей книги. (нажмите 9)");
                Console.WriteLine("Получение списка всех книг, отсортированного в алфавитном порядке по названию. (нажмите 10)");
                Console.WriteLine("Получение списка всех книг, отсортированного в порядке убывания года их выхода. (нажмите 11)");
                Console.WriteLine("Выйти (нажмите 0)");

                string keyValue = Console.ReadLine();

                if (keyValue == "0") break;

                switch (keyValue)
                {
                    case "1":
                        {
                            Program.addingBookView.Show();
                            break;
                        }
                    case "2":
                        {
                            Program.removingBookView.Show();
                            break;
                        }
                    case "3":
                        {
                            //Program.updateBookView.Show();
                            break;
                        }
                    case "4":
                        {
                            Program.searchingBooksView.Show();
                            break;
                        }
                    case "5":
                        {
                            Console.WriteLine("Введите название жанра книг, количетсво которых хотите получить:");

                            string booksGenre = Console.ReadLine();

                            var booksCount = bookRepository.CountByGenre(booksGenre);

                            Console.WriteLine($"Количетсво книг жанра {booksGenre}: {booksCount}\n");

                            break;
                        }
                    case "6":
                        {
                            Console.WriteLine("Введите название автора книг, количетсво которых хотите получить:");

                            string booksAuthor = Console.ReadLine();

                            var booksCount = bookRepository.CountByGenre(booksAuthor);

                            Console.WriteLine($"Количетсво книг автора {booksAuthor}: {booksCount}\n");

                            break;
                        }
                    case "7":
                        {
                            Console.WriteLine("Введите название книги, которую хотите проверить:");

                            string bookName = Console.ReadLine();

                            Console.WriteLine("Введите название автора книги, которую хотите проверить:");

                            string bookAuthor = Console.ReadLine();

                            if (bookRepository.CheckBookExistance(bookName, bookAuthor))
                            {
                                Console.WriteLine($"Книга присутсвует в библиотеке\n");
                            }
                            else
                            {
                                Console.WriteLine($"Книга отсуствует в библиотеке\n");
                            }

                            break;
                        }
                    case "8":
                        {
                            Console.WriteLine("Введите Id книги, которую хотите проверить:");

                            int bookId = int.Parse(Console.ReadLine());

                            var book = bookRepository.FindById(bookId);

                            if (book == null)
                            {
                                Console.WriteLine("Книги с таким Id не существует.\n");
                                break;
                            }

                            Console.WriteLine("Введите Id пользователя, у которого хотите проверить наличие книги:");

                            int userId = int.Parse(Console.ReadLine());

                            var user = userRepository.FindById(userId);

                            if (user == null)
                            {
                                Console.WriteLine("Пользователя с таким Id не существует.\n");
                                break;
                            }

                            if (bookRepository.CheckBookRecievedByUser(book, user))
                            {
                                Console.WriteLine($"Книга выдана пользователю\n");
                            }
                            else
                            {
                                Console.WriteLine($"Книга отсуствует у пользователя\n");
                            }

                            break;
                        }
                    case "9":
                        {
                            var book = bookRepository.GetLastPublishedBook();

                            Console.WriteLine("Последняя вышедшая книга:");

                            Console.WriteLine($"{book.Id} {book.Name} {book.Author} {book.PublicationDate.ToString("dd/MM/yyyy")} {book.Genre}\n");

                            break;
                        }
                    case "10":
                        {
                            books = bookRepository.GetAllOrderedByName();

                            Program.showingBooksView.Show(books);

                            break;
                        }
                    case "11":
                        {
                            books = bookRepository.GetAllOrderedByDescendingPublicationDate();

                            Program.showingBooksView.Show(books);

                            break;
                        }
                }
            }
        }
    }
}
