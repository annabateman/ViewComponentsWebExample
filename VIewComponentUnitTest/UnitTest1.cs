using DataProvider;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViewComponentsWebExample.CustomComponents;

namespace VIewComponentUnitTest {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void TestMethod1() {
            
            // Arrange
            var httpContext = new DefaultHttpContext(); 

            var viewContext = new ViewContext();
            viewContext.HttpContext = httpContext;
            var viewComponentContext = new ViewComponentContext();
            viewComponentContext.ViewContext = viewContext;

            var viewComponent = new FilmDetailViewComponent();
            viewComponent.ViewComponentContext = viewComponentContext;
            var film = new Film() {
                EpisodeId = 4,
                Title = "A New Hope"
            };

            //Act
            var result = viewComponent.Invoke(film) as ViewViewComponentResult;
            var model = result.ViewData.Model as Film;

            //Assert
            Assert.AreEqual(4, model.EpisodeId);
            Assert.AreEqual("A New Hope", film.Title);
        }
    }
}
