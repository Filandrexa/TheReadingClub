using System.Collections.Generic;
using TheReadingClub.Models.BookModels;

namespace TheReadingClub.Models.GenreModels
{
    public class GenreByIdViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<AllBooksViewModel> Books { get; set; }
    }
}
