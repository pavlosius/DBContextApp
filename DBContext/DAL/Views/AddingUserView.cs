using DBContextApp.BLL.Services;
using DBContextApp.BLL.Models;

namespace DBContextApp.PLL.Views
{
    public class AddingUserView
    {
        UserService userService;
        public AddingUserView(UserService userService)
        {
            this.userService = userService;
        }
        public void Show()
        {
            Console.WriteLine("Введите имя пользователя которого хотите добавить: ");
            string newUserName = Console.ReadLine();
            Console.WriteLine("Введите почтовый адрес пользователя которого хотите добавить: ");
            string newUserEmail = Console.ReadLine();

            userService.Add(newUserName, newUserEmail);
            Console.WriteLine("Пользователь успешно добавлен.");
        }
    }
}
