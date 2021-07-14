using System;
using System.ComponentModel.DataAnnotations;

namespace TheReadingClub.Models.BookViewModels
{
    public class AddBookFormModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        public int AuthorId { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public string ImageURL { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}
