using DBContextApp.BLL.Services;
using DBContextApp.BLL.Models;
using DBContextApp.DAL.Repositories;

namespace DBContextApp.PLL.Views
{
    public class AddingUserView
    {
        //UserService userService;
        //public AddingUserView(UserService userService)
        //{
        //    this.userService = userService;
        //}

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
            //userRepository.Add(newUserName, newUserEmail);
            Console.WriteLine("Пользователь успешно добавлен.");
        }
    }
}
