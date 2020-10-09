using System.Collections.Generic;
using GimcheonLibrary.DataAccess.Models;

namespace GimcheonLibrary.Web.Models
{
    public class AuthorBooksViewModel
    {
        public Author Author { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}
