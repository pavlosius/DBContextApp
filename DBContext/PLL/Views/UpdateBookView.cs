using DBContextApp.BLL.Services;
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
                Console.WriteLine("Введите Id книги, данные которой хотите изменить: ");

                int bookId = int.Parse(Console.ReadLine());

                Book book = bookRepository.FindById(bookId);

                while (true)
                {
                    Console.WriteLine("Изменение имени пользователя (нажмите 1)");
                    Console.WriteLine("Получение книги пользователем (нажмите 2)");
                    Console.WriteLine("Возврат книги пользователем (нажмите 3)");
                    Console.WriteLine("Выйти (нажмите 0)");

                    string keyValue = Console.ReadLine();

                    if (keyValue == "0") break;

                    switch (keyValue)
                    {
                        case "1":
                            {
                                //Program.updateUserNameView.Show(user);
                                break;
                            }
                        case "2":
                            {
                                //Program.addingBooksToUserView.Show(user);
                                break;
                            }
                        case "3":
                            {
                                //Program.removingBooksFromUserView.Show(user);
                                break;
                            }
                    }
                }
            }
            catch (ItemNotFoundException)
            {
                Console.WriteLine("Книга с таким Id не найдена!");
            }


            //try
            //{
            //    Console.WriteLine("Введите Id пользователя, имя которого хотите изменить: ");

            //    int userId = int.Parse(Console.ReadLine());

            //    User user = userRepository.FindById(userId);

            //    Console.WriteLine("Введите новое имя пользователя: ");

            //    string newUserName = Console.ReadLine();

            //    user.Name = newUserName;

            //    userRepository.Update(user);

            //    Console.WriteLine("Имя пользователя успешно изменено.");
            //}
            //catch (UserNotFoundException)
            //{
            //    Console.WriteLine("Пользователь с таким Id не найден!");
            //}
        }
    }
}
