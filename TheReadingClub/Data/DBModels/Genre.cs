using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheReadingClub.Data.DBModels
{
    public class Genre
    {
        public Genre()
        {
            this.Books = new HashSet<Book>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
