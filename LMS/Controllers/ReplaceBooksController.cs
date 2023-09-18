using Microsoft.AspNetCore.Mvc;
using LMS_Management.ReplacingBooks;
using Newtonsoft.Json;

namespace LMS.Controllers
{
    public class ReplaceBooksController : Controller
    {
        private ReplacingBooks game = new ReplacingBooks();
        public IActionResult Index()
        {        
            List<string> callNumbers = game.GenerateCallNumbers();
            ViewBag.Items = callNumbers;
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
