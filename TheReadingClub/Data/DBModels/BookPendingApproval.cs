using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheReadingClub.Data.DBModels
{
    public class BookPendingApproval
    {
        public BookPendingApproval()
        {
            this.Genres = new List<Genre>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }

        public ICollection<Genre> Genres { get; set; }

        [Required]
        [MaxLength(5000)]
        public string Description { get; set; }

        [Required]
        public string ImageURL { get; set; }

        public int ReleaseYear { get; set; }
    }
}
