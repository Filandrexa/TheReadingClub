using TheReadingClub.Data.DBModels;
using TheReadingClub.Models.AuthorViewModels;

namespace TheReadingClub.Services.FormModelServices
{
    public interface IAuthorFormModel
    {
        public void AddAuthor(AddAuthorFormModel author);
    }
}
