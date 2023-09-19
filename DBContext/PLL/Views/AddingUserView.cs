using DBContextApp.BLL.Models;
using DBContextApp.DAL.Repositories;

namespace DBContextApp.PLL.Views
{
    public class AddingUserView
    {
        UserRepository userRepository;
        public AddingUserView(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public void Show()
        {
            Console.WriteLine("Введите имя пользователя, которого хотите добавить: ");

            string newUserName = Console.ReadLine();

            Console.WriteLine("Введите почтовый адрес пользователя, которого хотите добавить: ");

            string newUserEmail = Console.ReadLine();
            
            var newUser = new User()
            {
                Name = newUserName,
                Email = newUserEmail,
            };

            userRepository.Add(newUser);

            Console.WriteLine("Пользователь успешно добавлен.");
        }
    }
}
