using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TheReadingClub.Models.AuthorModels;
using TheReadingClub.Models.BookViewModels;

namespace TheReadingClub.Models.BookModels
{
    public class EditBookFormModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Title")]
        [RegularExpression("[А-Яа-яA-Za-z. ']*")]
        [StringLength(100)]
        public string Title { get; set; }
        
        [Display(Name = "Full Name")]
        public ICollection<AuthorBookSelectFormModel> Author { get; set; }

        [Display(Name = "Full Name")]
        public int AuthorId { get; set; }

        [Required]
        [Display(Name = "Discription")]
        [MaxLength(5000)]
        public string Description { get; set; }

        [Required]
        [Url]
        public string ImageURL { get; set; }

        [Required]
        [RegularExpression("[0-9]{0,4}")]
        public int ReleaseYear { get; set; }

        [Display(Name = "Genres selection")]
        public ICollection<int> GenresId { get; set; }

        [Display(Name = "Genres selection")]
        public ICollection<GenreViewModel> Genres { get; set; }
    }
}
