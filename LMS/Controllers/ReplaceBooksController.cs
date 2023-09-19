using Microsoft.AspNetCore.Mvc;
using LMS_Management.ReplacingBooks;
using Newtonsoft.Json;

namespace LMS.Controllers
{
    public class ReplaceBooksController : Controller
    {
        private ReplacingBooks game = new ReplacingBooks();
        private Dictionary<string, string> levels = new Dictionary<string, string>();

        public IActionResult Index()
        {        
            List<string> callNumbers = game.GenerateCallNumbers();
            ViewBag.Items = callNumbers;

            levels = game.GameLevelDescription();

            //get the value where the key equals Easy
            ViewBag.Levels = levels;

            return View();
        }

        [HttpPost]
        public IActionResult SubmitSortedItems([FromBody] string[] sortedItems)
        {
            var items = sortedItems.ToList();

            var result = game.CheckOrder(items);

            return Ok();
        }

    }
}
