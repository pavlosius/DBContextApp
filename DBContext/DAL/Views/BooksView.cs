using DBContextApp.BLL.Services;


namespace DBContextApp.PLL.Views
{
    public class BooksView
    {
        UserService userService;
        public BooksView(UserService userService)
        {
            this.userService = userService;
        }
        public void Show()
        {
            var books = userService.FindAll();
            foreach (var user in books)
            {
                Console.WriteLine($"{user.Id} {user.Name} {user.Email}");
            }
        }
    }
}
