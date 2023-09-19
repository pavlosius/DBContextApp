using DBContextApp.BLL.Services;
using DBContextApp.BLL.Models;
using DBContextApp.BLL.Exceptions;
using DBContextApp.DAL.Repositories;

namespace DBContextApp.PLL.Views
{
    public class RemovingBookView
    {
        //UserService userService;
        //public RemovingUserView(UserService userService)
        //{
        //    this.userService = userService;
        //}

        BookRepository bookRepository;
        public RemovingBookView(BookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public void Show()
        {
            try
            {
                Console.WriteLine("Введите Id книги, которую хотите удалить: ");

                int bookId = int.Parse(Console.ReadLine());

                Book book = bookRepository.FindById(bookId);

                bookRepository.Remove(book);

                //userRepository.RemoveById(userId);

                Console.WriteLine("Книга успешно удалена.");
            }
            catch (ItemNotFoundException)
            {
                Console.WriteLine("Книга с таким Id не найдена!");
            }

        }
    }
}
