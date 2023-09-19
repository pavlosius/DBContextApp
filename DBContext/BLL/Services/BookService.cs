using DBContextApp.DAL.Repositories;
using DBContextApp.BLL.Models;
using DBContextApp.BLL.Exceptions;
using System.Numerics;

namespace DBContextApp.BLL.Services
{
    public class BookService : BaseService<Book>
    {
        BookRepository bookRepository;

        public BookService(DBContextApp.DAL.AppContext appContext) : base(appContext)
        {
            bookRepository = new BookRepository(appContext);
        }

        //friends.ToList().ForEach(friend =>
        //    {
        //    Console.WriteLine("Почтовый адрес друга: {0}. Имя друга: {1}. Фамилия друга: {2}", friend.Email, friend.FirstName, friend.LastName);
        //});


    }
}
