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
    }
}
