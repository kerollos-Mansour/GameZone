using GameZone.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GameZone.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGamesServices _gamesServices;

        public HomeController(IGamesServices gamesServices)
        {
			_gamesServices = gamesServices; 

		}

        public IActionResult Index()
        {
            var games=_gamesServices.GetAll();
            return View(games);
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
