using DBContextApp.BLL.Services;
using DBContextApp.BLL.Models;
using DBContextApp.BLL.Exceptions;
using DBContextApp.DAL.Repositories;

namespace DBContextApp.PLL.Views
{
    public class RemovingUserView
    {
        //UserService userService;
        //public RemovingUserView(UserService userService)
        //{
        //    this.userService = userService;
        //}

        UserRepository userRepository;
        public RemovingUserView(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public void Show()
        {
            try
            {
                Console.WriteLine("Введите Id пользователя, которого хотите удалить: ");

                int userId = int.Parse(Console.ReadLine());

                User user = userRepository.FindById(userId);
                userRepository.Remove(user);
                //userRepository.RemoveById(userId);

                Console.WriteLine("Пользователь успешно удален.");
            }
            catch (ItemNotFoundException)
            {
                Console.WriteLine("Пользователь с таким Id не найден!");
            }

        }
    }
}
