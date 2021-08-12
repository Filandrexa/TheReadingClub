using Xunit;
using MyTested.AspNetCore.Mvc;
using TheReadingClub.Controllers;
using static TheReadingClub.Tests.Data.Books;
using static TheReadingClub.Tests.Data.Genres;
using static TheReadingClub.Tests.Data.Authors;
using TheReadingClub.Models.BookViewModels;
using System.Collections.Generic;
using System.Linq;

namespace TheReadingClub.Tests.ControllerTests
{
    public class BookControllerTests
    {
        [Fact]
        public void GetAddShouldViewWithCorrectModelWithData()
            => MyController<BookController>
                .Instance(c => c.WithData(TenBooks))
                .Calling(c => c.Add())
                .ShouldReturn()
                .View(v => v.WithModelOfType<AddBookFormModel>());

        [Fact]
        public void PostAddShouldTheViewWhenTheDataIsIncorect()
            => MyController<BookController>
                .Instance()
                .Calling(c => c.Add(new AddBookFormModel { }))
                .ShouldHave()
                .ActionAttributes(a => a.RestrictingForHttpMethod(HttpMethod.Post))
                .AndAlso()
                .ShouldHave()
                .InvalidModelState()
                .AndAlso()
                .ShouldReturn()
                .View(v => v.WithModelOfType<AddBookFormModel>());

        [Fact]
        public void PostAddSouldRedirectToCorrectActionWhenTheDataIsValid()
            => MyController<BookController>
                .Instance()
                .Calling(c => c.Add(new AddBookFormModel {}))
                .ShouldHave()
                .ActionAttributes(a => a.RestrictingForHttpMethod(HttpMethod.Post))
                .AndAlso()
                .ShouldHave()
                .ValidModelState()
                .AndAlso()
                .ShouldReturn()
                .RedirectToAction("Index", "Home");
    }
}
