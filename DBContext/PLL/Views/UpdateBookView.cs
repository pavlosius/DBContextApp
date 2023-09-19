using DBContextApp.BLL.Models;
using DBContextApp.DAL.Repositories;
using DBContextApp.BLL.Exceptions;

namespace DBContextApp.PLL.Views
{
    public class UpdateBookView
    {
        BookRepository bookRepository;
        public UpdateBookView(BookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public void Show()
        {
            try
            {
                Console.WriteLine("Введите Id книги, данные которой хотите изменить:");

                int bookId = int.Parse(Console.ReadLine());

                Book book = bookRepository.FindById(bookId);

                while (true)
                {
                    Console.WriteLine("Изменение жанра книги (нажмите 1)");
                    Console.WriteLine("Выйти (нажмите 0)");

                    string keyValue = Console.ReadLine();

                    if (keyValue == "0") break;

                    switch (keyValue)
                    {
                        case "1":
                            {
                                Console.WriteLine("Введите новое название жанра книги: ");

                                string newBookGenre = Console.ReadLine();

                                book.Genre = newBookGenre;

                                bookRepository.Update(book);

                                Console.WriteLine("Жанр книги успешно изменен.");
                                break;
                            }
                    }
                }
            }
            catch (ItemNotFoundException)
            {
                Console.WriteLine("Книга с таким Id не найдена!");
            }
        }
    }
}
