using DBContextApp.BLL.Models;
using DBContextApp.DAL.Repositories;
using DBContextApp.PLL.Views;

class Program
{
    //static UserService userService;
    //public static EFBaseRepository<User> userRepository;
    public static UserRepository userRepository;
    public static BookRepository bookRepository;

    public static MainView mainView;

    public static UsersView usersView;
    public static AddingUserView addingUserView;
    public static RemovingUserView removingUserView;
    public static UpdateUserView updateUserView;
    public static UpdateUserNameView updateUserNameView;
    public static AddingBooksToUserView addingBooksToUserView;
    public static RemovingBooksFromUserView removingBooksFromUserView;
    
    public static BooksView booksView;
    public static AddingBookView addingBookView;
    public static RemovingBookView removingBookView;
    public static ShowingBooksView showingBooksView;
    public static SearchingBooksView searchingBooksView;


    static void Main(string[] args)
    {
        mainView = new MainView();

        //userService = new UserService(new DBContextApp.DAL.AppContext());
        //userRepository = new EFBaseRepository<User>(new DBContextApp.DAL.AppContext());
        userRepository = new UserRepository(new DBContextApp.DAL.AppContext());
        bookRepository = new BookRepository(new DBContextApp.DAL.AppContext());

        //usersView = new UsersView(userService);
        //addingUserView = new AddingUserView(userService);
        //removingUserView= new RemovingUserView(userService);

        usersView = new UsersView(userRepository);
        addingUserView = new AddingUserView(userRepository);
        removingUserView = new RemovingUserView(userRepository);
        updateUserView = new UpdateUserView(userRepository);
        updateUserNameView = new UpdateUserNameView(userRepository);
        addingBooksToUserView = new AddingBooksToUserView(userRepository,bookRepository);
        removingBooksFromUserView = new RemovingBooksFromUserView(userRepository, bookRepository);

        booksView = new BooksView(bookRepository,userRepository);
        addingBookView = new AddingBookView(bookRepository);
        removingBookView = new RemovingBookView(bookRepository);
        showingBooksView = new ShowingBooksView(bookRepository);
        searchingBooksView = new SearchingBooksView(bookRepository);


        //var user1 = new User { Name = "Arthur", Email = "Arthur@mail.com" };
        //var user2 = new User { Name = "klim", Email = "klim@mail.com" };

        //var book1 = new Book { Name = "Popular Mechanics", PublicationDate = new DateTime(2000, 12, 1), Genre = "Science" };
        //var book2 = new Book { Name = "LIFE", Author = "Man", PublicationDate = new DateTime(1933, 8, 30) };

        //user1.Books.Add(book1);
        //user2.Books.AddRange(new[] { book1, book2 });

        //userRepository.Add(user1);
        //userRepository.Add(user2);
        //bookRepository.Add(book1);
        //bookRepository.Add(book2);


        using (var db = new DBContextApp.DAL.AppContext())
        {
            var user1 = new User { Name = "Arthur", Email = "Arthur@mail.com" };
            var user2 = new User { Name = "klim", Email = "klim@mail.com" };

            var book1 = new Book { Name = "Popular Mechanics", PublicationDate = new DateTime(2000, 12, 1), Genre = "Science" };
            var book2 = new Book { Name = "LIFE", Author = "Man", PublicationDate = new DateTime(1933, 8, 30) };

            user1.Books.Add(book1);
            user2.Books.AddRange(new[] { book1, book2 });

            //book1.Users.AddRange(new[] { user1, user2 });
            //book2.Users.Add(user2);

            db.Users.Add(user1);
            db.Users.Add(user2);
            db.Books.AddRange(book1, book2);

            db.SaveChanges();
        }



        while (true)
        {
            mainView.Show();
        }
    }
}
