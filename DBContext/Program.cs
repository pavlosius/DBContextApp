using DBContextApp.BLL.Models;
using DBContextApp.DAL.Repositories;
using DBContextApp.PLL.Views;

class Program
{
    public static UserRepository userRepository;
    public static BookRepository bookRepository;

    public static MainView mainView;

    public static UsersView usersView;
    public static AddingUserView addingUserView;
    public static RemovingUserView removingUserView;
    public static UpdateUserView updateUserView;
    public static AddingBooksToUserView addingBooksToUserView;
    public static RemovingBooksFromUserView removingBooksFromUserView;
    
    public static BooksView booksView;
    public static AddingBookView addingBookView;
    public static RemovingBookView removingBookView;
    public static UpdateBookView updateBookView;
    public static ShowingBooksView showingBooksView;
    public static SearchingBooksView searchingBooksView;


    static void Main(string[] args)
    {
        mainView = new MainView();

        userRepository = new UserRepository(new DBContextApp.DAL.AppContext());
        bookRepository = new BookRepository(new DBContextApp.DAL.AppContext());

        usersView = new UsersView(userRepository);
        addingUserView = new AddingUserView(userRepository);
        removingUserView = new RemovingUserView(userRepository);
        updateUserView = new UpdateUserView(userRepository);
        addingBooksToUserView = new AddingBooksToUserView(userRepository,bookRepository);
        removingBooksFromUserView = new RemovingBooksFromUserView(userRepository, bookRepository);

        booksView = new BooksView(bookRepository,userRepository);
        addingBookView = new AddingBookView(bookRepository);
        removingBookView = new RemovingBookView(bookRepository);
        updateBookView = new UpdateBookView(bookRepository);
        showingBooksView = new ShowingBooksView(bookRepository);
        searchingBooksView = new SearchingBooksView(bookRepository);


        using (var db = new DBContextApp.DAL.AppContext())
        {
            var user1 = new User { Name = "Arthur", Email = "Arthur@mail.com" };
            var user2 = new User { Name = "klim", Email = "klim@mail.com" };

            var book1 = new Book { Name = "Popular Mechanics", PublicationDate = new DateTime(2000, 12, 1), Genre = "Science" };
            var book2 = new Book { Name = "LIFE", Author = "Man", PublicationDate = new DateTime(1933, 8, 30) };
            var book3 = new Book { Name = "In Search of Lost Time", Author = "Marcel Proust", PublicationDate = new DateTime(1913, 12, 1),Genre= "Novel" };

            user1.Books.Add(book1);
            user2.Books.AddRange(new[] { book1, book2 });

            db.Users.Add(user1);
            db.Users.Add(user2);
            db.Books.AddRange(book1, book2, book3);

            db.SaveChanges();
        }

        while (true)
        {
            mainView.Show();
        }
    }
}
