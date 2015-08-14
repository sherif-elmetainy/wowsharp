using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using WOWSharp.Warcraft;

namespace WOWSharp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly WarcraftClient _wowClient;

        public HomeController(WarcraftClient wowClient)
        {
            _wowClient = wowClient;
        }

        public async Task<IActionResult> Index()
        {
            var character = await _wowClient.GetCharacterAsync("Kazzak", "Grendiser", CharacterFields.None);
            return View(character);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}
