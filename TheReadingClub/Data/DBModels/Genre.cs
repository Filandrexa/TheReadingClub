using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static TheReadingClub.ProjectConstants;

namespace TheReadingClub.Data.DBModels
{
    public class Genre
    {
        public Genre()
        {
            this.Books = new HashSet<Book>();
            this.PendingApproval = new HashSet<BookPendingApproval>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(GenreNameMaxLenght)]
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }

        public ICollection<BookPendingApproval> PendingApproval { get; set; }
    }
}
