using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheReadingClub.Models.BookViewModels
{
    public class AddBookFormModel
    {
        [Required]
        [Display(Name = "Title")]
        [RegularExpression("[А-Яа-яA-Za-z.]*")]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        [RegularExpression("[А-Яа-яA-Za-z.]*")]
        [StringLength(100)]
        public string Author { get; set; }

        [Required]
        [Display(Name = "Discription")]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        [Url]
        public string ImageURL { get; set; }

        [Required]
        [RegularExpression("[0-9]{4}")]
        public int ReleaseYear { get; set; }

        public ICollection<GenreViewModel> Genres { get; set; }
    }
}
