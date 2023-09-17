using Microsoft.AspNetCore.Mvc;
using LMS_Management.ReplacingBooks;

namespace LMS.Controllers
{
    public class ReplaceBooksController : Controller
    {
        public IActionResult Index()
        {
            ReplacingBooks game = new ReplacingBooks();

            List<string> callNumbers = game.GenerateCallNumbers();
            ViewBag.Items = callNumbers;
            return View();
        }
    }
}
