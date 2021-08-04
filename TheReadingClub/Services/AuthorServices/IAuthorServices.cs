using System.Collections.Generic;
using TheReadingClub.Models.AuthorModels;
using TheReadingClub.Models.AuthorViewModels;

namespace TheReadingClub.Services.FormModelServices
{
    public interface IAuthorServices
    {
        public bool AddAuthorToDB(AddAuthorFormModel author);

        public ICollection<AuthorsViewModel> PopulateAuthorsViewModel(string id);

        public AuthorViewModel PopulateAuthorViewModel(int id);

        public EditAuthorFormModel GetAuthorFromDb(int id);

        public bool EditAuthor(EditAuthorFormModel model);
    }
}
