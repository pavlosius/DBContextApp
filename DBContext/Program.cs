using DBContextApp.BLL.Models;
using DBContextApp.BLL.Services;
using DBContextApp.DAL.Repositories;
using DBContextApp.PLL.Views;

class Program
{
    //static UserService userService;
    //public static EFBaseRepository<User> userRepository;
    public static UserRepository userRepository;

    public static MainView mainView;
    public static UsersView usersView;
    public static BooksView booksView;
    public static AddingUserView addingUserView;
    public static RemovingUserView removingUserView;

    static void Main(string[] args)
    {
        using (var db = new DBContextApp.DAL.AppContext())
        {
            var user1 = new User { Name = "Arthur", Email = "Arthur@mail.com" };
            var user2 = new User { Name = "klim", Email = "klim@mail.com" };

            db.Users.Add(user1);
            db.Users.Add(user2);

            var book1 = new Book { Name = "Popular Mechanics", PublicationDate = new DateTime(2000, 12, 1) };
            var book2 = new Book { Name = "LIFE", PublicationDate = new DateTime(1933, 8, 30) };

            db.Books.AddRange(book1, book2);

            db.SaveChanges();
        }

        mainView = new MainView();

        //userService = new UserService(new DBContextApp.DAL.AppContext());
        //userRepository = new EFBaseRepository<User>(new DBContextApp.DAL.AppContext());
        userRepository = new UserRepository(new DBContextApp.DAL.AppContext());

        //usersView = new UsersView(userService);
        //addingUserView = new AddingUserView(userService);
        //removingUserView= new RemovingUserView(userService);

        usersView = new UsersView(userRepository);
        addingUserView = new AddingUserView(userRepository);
        removingUserView= new RemovingUserView(userRepository);



        while (true)
        {
            mainView.Show();
        }
    }
}
