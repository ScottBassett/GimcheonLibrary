using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GimcheonLibrary.DataAccess.Models
{
    public class Author : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string About { get; set; }

        public List<Book> Books { get; set; }
    }
}
