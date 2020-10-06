using System.ComponentModel.DataAnnotations;

namespace GimcheonLibrary.DataAccess.Models
{
    public class Book : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Total Copies")]
        public int TotalCopies { get; set; }

        [Required]
        [Display(Name = "Available Copies")]
        public int AvailableCopies { get; set; }

        public string ImageUrl { get; set; }
    }
}
