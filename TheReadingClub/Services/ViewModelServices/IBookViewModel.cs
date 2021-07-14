using System.Collections.Generic;
using TheReadingClub.Models.BookViewModels;

namespace TheReadingClub.Services.ViewModelServices
{
    public interface IBookViewModel
    {
        public ICollection<HomePageBookViewModel> homePageBooks();
    }
}
