using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBContextApp.BLL.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime PublicationDate { get; set; }
        public string? Author { get; set; }
        public string? Genre { get; set; }

        // Навигационное свойство
        public List<User> Users { get; set; } = new List<User>();
    }
}
