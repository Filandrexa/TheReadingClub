using System.Collections.Generic;
using TheReadingClub.Models.BookViewModels;
using TheReadingClub.Models.GenreModels;

namespace TheReadingClub.Services.GenreServices
{
    public interface IGenreServices
    {
        public ICollection<GenreViewModel> ViewAllGenres ();

        public GenreByIdViewModel GenreByIdView(int id); 
    }
}
