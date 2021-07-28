using System.Collections.Generic;
using TheReadingClub.Models.AuthorModels;
using TheReadingClub.Models.AuthorViewModels;

namespace TheReadingClub.Services.FormModelServices
{
    public interface IAuthor
    {
        public void AddAuthorToDB(AddAuthorFormModel author);

        public ICollection<AuthorsViewModel> PopulateAuthorsViewModel();

        public AuthorViewModel PopulateAuthorViewModel(int id);
    }
}
