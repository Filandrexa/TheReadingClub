using TheReadingClub.Models.BookViewModels;

namespace TheReadingClub.Services.FormModelServices
{
    interface IBookFormModel
    {
        public bool AddBook(AddBookFormModel book);
    }
}
