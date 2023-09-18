using DBContextApp.BLL.Services;
using DBContextApp.BLL.Models;
using DBContextApp.DAL.Repositories;
using DBContextApp.BLL.Exceptions;

namespace DBContextApp.PLL.Views
{
    public class UpdateUserNameView
    {
        UserRepository userRepository;
        public UpdateUserNameView(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public void Show(User user)
        {
            //try
            //{
                Console.WriteLine("Введите новое имя пользователя: ");

                string newUserName = Console.ReadLine();

                user.Name = newUserName;

                userRepository.Update(user);

                Console.WriteLine("Имя пользователя успешно изменено.");
            //}
            //catch (UserNotFoundException)
            //{
            //    Console.WriteLine("Пользователь с таким Id не найден!");
            //}
        }
    }
}
