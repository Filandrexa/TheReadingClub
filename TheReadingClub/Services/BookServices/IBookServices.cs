using System.Collections.Generic;
using TheReadingClub.Models.BookModels;
using TheReadingClub.Models.BookViewModels;

namespace TheReadingClub.Services.BookServices
{
    public interface IBookServices
    {
        public bool AddBook(AddBookFormModel book);

        public ICollection<IndexBookViewModel> PopulateIndexBooks();

        public BookByIdViewModel BookById(int id);

        public ICollection<AllBooksViewModel> AllBooks();

        public EditBookFormModel PopulateEditBookFormModel(int id);

        public bool EditBook(EditBookFormModel model);
    }
}
