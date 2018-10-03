using DataProvider;
using Microsoft.AspNetCore.Mvc;


namespace ViewComponentsWebExample.CustomComponents {
    
    public class FilmDetailViewComponent : ViewComponent {
        public IViewComponentResult Invoke(Film film) {
            return View(film);
        }
    }
}
