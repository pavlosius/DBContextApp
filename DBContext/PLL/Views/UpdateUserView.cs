using DBContextApp.BLL.Services;
using DBContextApp.BLL.Models;
using DBContextApp.DAL.Repositories;
using DBContextApp.BLL.Exceptions;

namespace DBContextApp.PLL.Views
{
    public class UpdateUserView
    {
        UserRepository userRepository;
        public UpdateUserView(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public void Show()
        {
            try
            {
                Console.WriteLine("Введите Id пользователя, данные которого хотите изменить: ");

                int userId = int.Parse(Console.ReadLine());

                User user = userRepository.FindById(userId);

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
                                Program.updateUserNameView.Show(user);
                                break;
                            }
                        case "2":
                            {
                                Program.addingBooksToUserView.Show(user);
                                break;
                            }
                        case "3":
                            {
                                Program.removingBooksFromUserView.Show(user);
                                break;
                            }
                    }
                }
            }
            catch (ItemNotFoundException)
            {
                Console.WriteLine("Пользователь с таким Id не найден!");
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
