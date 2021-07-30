using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TheReadingClub.Models.AuthorModels;

namespace TheReadingClub.Models.BookViewModels
{
    public class AddBookFormModel
    {
        [Required]
        [Display(Name = "Title")]
        [RegularExpression("[А-Яа-яA-Za-z. ']*")]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        [StringLength(100)]
        public ICollection<AuthorBookSelectFormModel> Author { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        [StringLength(100)]
        public int AuthorId { get; set; }

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

        [Required]
        public ICollection<GenreViewModel> Genres { get; set; }
    }
}
