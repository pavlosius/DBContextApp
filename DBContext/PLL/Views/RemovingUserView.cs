using DBContextApp.BLL.Models;
using DBContextApp.BLL.Exceptions;
using DBContextApp.DAL.Repositories;

namespace DBContextApp.PLL.Views
{
    public class RemovingUserView
    {
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

                Console.WriteLine("Пользователь успешно удален.");
            }
            catch (ItemNotFoundException)
            {
                Console.WriteLine("Пользователь с таким Id не найден!");
            }
        }
    }
}
