using Xunit;
using MyTested.AspNetCore.Mvc;
using TheReadingClub.Controllers;
using TheReadingClub.Models.BookModels;
using System.Collections.Generic;
using static TheReadingClub.Tests.Data.Books;

namespace TheReadingClub.Tests.ControllerTests
{
    public class HomeControllerTest
    {
        [Fact]
        public void IndexShouldReturnViewWithCorrectData()
        => MyController<HomeController>
            .Instance(c=> c.WithData(TenBooks))
            .Calling(c => c.Index())
            .ShouldReturn()
            .View(v=> 
                    v.WithModelOfType<List<IndexBookViewModel>>()
                    .Passing(m=> m.Count.CompareTo(3)));
    }
}
