using DBContextApp.BLL.Services;
using DBContextApp.BLL.Models;
using DBContextApp.DAL.Repositories;
using System;

namespace DBContextApp.PLL.Views
{
    public class SearchingBooksView
    {
        BookRepository bookRepository;
        public SearchingBooksView(BookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public void Show()
        {
            Console.WriteLine("Введите название жанра книг, которых хотите найти:");
            
            string bookGenre = Console.ReadLine();
            
            Console.WriteLine("Введите начало интервала дат публикаций книги, которых хотите найти: ");
            
            DateTime bookPublicationDateStart;
            
            if( DateTime.TryParse(Console.ReadLine(), out bookPublicationDateStart) != true)
            {
                Console.WriteLine("Введна неверная дата!");
                return;
            }

            Console.WriteLine("Введите конец интервала дат публикаций книг, которых хотите найти: ");
            
            DateTime bookPublicationDateEnd;

            if (DateTime.TryParse(Console.ReadLine(), out bookPublicationDateEnd) != true)
            {
                Console.WriteLine("Введна неверная дата!");
                return;
            }

            var books = bookRepository.Find(bookGenre, bookPublicationDateStart, bookPublicationDateEnd);

            Program.showingBooksView.Show(books);
        }
    }
}
