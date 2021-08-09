using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static TheReadingClub.ProjectConstants;

namespace TheReadingClub.Data.DBModels
{
    public class Author
    {
        public Author()
        {
            this.Books = new HashSet<Book>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(AuthorNameMaxLenght)]
        public string FullName { get; set; }

        public ICollection<Book> Books { get; set; }

        [Required]
        public string ImageURL { get; set; }
    }
}
