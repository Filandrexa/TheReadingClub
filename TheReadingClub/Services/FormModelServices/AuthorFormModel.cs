using TheReadingClub.Data;
using TheReadingClub.Data.DBModels;
using TheReadingClub.Models.AuthorViewModels;

namespace TheReadingClub.Services.FormModelServices
{
    public class AuthorFormModel : IAuthorFormModel
    {
        private TheReadingClubDbContext data;

        public AuthorFormModel(TheReadingClubDbContext data)
        {
            this.data = data;
        }

        public void AddAuthor(AddAuthorFormModel author)
        {
            var authorToAdd = new Author
            {
                FullName = author.FullName,
                ImageURL = author.ImageURL,
            };

            data.Authors.Add(authorToAdd);
            data.SaveChanges();
        }
    }
}
