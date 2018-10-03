using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataProvider;
using Microsoft.AspNetCore.Mvc;
using ViewComponentsWebExample.Models;

namespace ViewComponentsWebExample.Controllers {
    public class HomeController : Controller {
        public IActionResult Index() {
            return View();
        }

        public async Task<IActionResult> FilmView(int filmId) {
            StarWarsApi<Film> apiResult = new StarWarsApi<Film>();
            FilmViewModel model = new FilmViewModel() {
                Film = await apiResult.RetrieveItem("films", filmId)
            };
            return View(model);
        }

        public IActionResult About() {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact() {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
