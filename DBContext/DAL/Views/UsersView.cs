using DBContextApp.BLL.Models;
using DBContextApp.BLL.Services;
using DBContextApp.DAL.Repositories;

namespace DBContextApp.PLL.Views
{
    public class UsersView
    {
        //UserService userService;
        //public UsersView(UserService userService)
        //{
        //    this.userService = userService;
        //}

        UserRepository userRepository;

        public UsersView(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public void Show()
        {
            while (true)
            {
                Console.WriteLine("Список пользователей:");
                var users = userRepository.FindAll();
                foreach (var user in users)
                {
                    Console.WriteLine($"{user.Id} {user.Name} {user.Email}");
                }

                Console.WriteLine("Добавление пользователя (нажмите 1)");
                Console.WriteLine("Удаление пользователя (нажмите 2)");
                Console.WriteLine("Изменение данных пользователя (нажмите 3)");
                Console.WriteLine("Выйти (нажмите 4)");

                string keyValue = Console.ReadLine();

                if (keyValue == "4") break;

                switch (keyValue)
                {
                    case "1":
                        {
                            Program.addingUserView.Show();
                            break;
                        }
                    case "2":
                        {
                            Program.removingUserView.Show();
                            break;
                        }
                    case "3":
                        {
                            Program.updateUserView.Show();
                            break;
                        }
                }
            }
        }
    }
}
