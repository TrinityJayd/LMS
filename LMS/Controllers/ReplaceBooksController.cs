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
            ViewBag.Levels = levels;

            return View();
        }

        [HttpPost]
        public IActionResult SubmitSortedItems([FromBody] string[] sortedItems)
        {
            //convert the array to a list
            var items = sortedItems.ToList();

            //check the order of the items
            var result = game.CheckOrder(items);

            return Ok();
        }

    }
}
