using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GimcheonLibrary.DataAccess.Models
{
    public class AuthorsBooks : BaseEntity
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int BookId { get; set; }
    }
}
