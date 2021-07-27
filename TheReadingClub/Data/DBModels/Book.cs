using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheReadingClub.Data.DBModels
{
    public class Book
    {
        public Book()
        {
            this.Genres = new HashSet<Genre>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        public int AuthorId { get; set; }

        public Author Autor { get; set; }

        public ICollection<Genre> Genres { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public string ImageURL { get; set; }

        public int ReleaseYear { get; set; }
    }
}
