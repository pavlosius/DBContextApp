namespace DBContextApp.PLL.Views
{
    public class MainView
    {
        public void Show()
        {
            Console.WriteLine("Управление пользователями (нажмите 1)");
            Console.WriteLine("Управление книгами (нажмите 2)");

            switch (Console.ReadLine())
            {
                case "1":
                    {
                        Program.usersView.Show();
                        break;
                    }

                case "2":
                    {
                        Program.booksView.Show();
                        break;
                    }
            }
        }
    }
}
