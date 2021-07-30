using TheReadingClub.Models.BookViewModels;

namespace TheReadingClub.Services.BookServices
{
    public interface IBookServices
    {
        public bool AddBook(AddBookFormModel book);
    }
}
