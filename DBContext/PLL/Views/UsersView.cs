using DBContextApp.DAL.Repositories;

namespace DBContextApp.PLL.Views
{
    public class UsersView
    {
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
                Console.WriteLine("Количество книг на руках у пользователя (нажмите 4)");
                Console.WriteLine("Выйти (нажмите 0)");

                string keyValue = Console.ReadLine();

                if (keyValue == "0") break;

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
                    case "4":
                        {
                            Console.WriteLine("Введите Id пользователя, у которого хотите узнать количество книг в наличии:");

                            int userId = int.Parse(Console.ReadLine());

                            var user = userRepository.FindById(userId);

                            if (user == null)
                            {
                                Console.WriteLine("Пользователя с таким Id не существует.\n");
                                break;
                            }

                            var booksCount = userRepository.CountOfBooksRecievedByUser(user);

                            Console.WriteLine($"Количество книг на руках у пользователя с Id {userId}: {booksCount}\n");
                            break;
                        }
                }
            }
        }
    }
}
