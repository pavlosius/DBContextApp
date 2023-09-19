using DBContextApp.BLL.Services;
using DBContextApp.BLL.Models;
using DBContextApp.DAL.Repositories;
using System;

namespace DBContextApp.PLL.Views
{
    public class AddingBookView
    {
        //UserService userService;
        //public AddingUserView(UserService userService)
        //{
        //    this.userService = userService;
        //}

        BookRepository bookRepository;
        public AddingBookView(BookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public void Show()
        {
            Console.WriteLine("Введите название книги, которою хотите добавить: ");
            
            string newBookName = Console.ReadLine();
            
            Console.WriteLine("Введите дату публикации книги, которую хотите добавить: ");
            
            DateTime newBookPublicationDate;
            
            var s = DateTime.TryParse(Console.ReadLine(), out newBookPublicationDate);
            
            Console.WriteLine("Введите автора книги, которую хотите добавить: ");
            
            string newBookAuthor = Console.ReadLine();
            
            Console.WriteLine("Введите жанр книги, которую хотите добавить: ");
           
            string newBookGenre = Console.ReadLine();

            var newBook = new Book()
            {
                Name = newBookName,
                PublicationDate = newBookPublicationDate,
                Author = newBookAuthor,
                Genre = newBookGenre
            };
           
            bookRepository.Add(newBook);
            //userRepository.Add(newUserName, newUserEmail);
            Console.WriteLine("Книга успешно добавлена в библиотеку.");


        }
    }
}
