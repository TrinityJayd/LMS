using LMS.Models;
using LMS_Management.IdentifyingAreas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace LMS.Controllers
{
    public class IdentifyingAreasController : Controller
    {
        private IdentifyingAreas identifyingAreas = new IdentifyingAreas();
        private Dictionary<string, string> levels = new Dictionary<string, string>();

        public ActionResult Index()
        {
            levels = identifyingAreas.GameLevelDescription();
            ViewBag.Levels = levels;
            IdentifyingAreasModel areasModel = new IdentifyingAreasModel();
            areasModel.Areas = identifyingAreas.GenerateAreas("Call Numbers to Description");
            areasModel.Extras = identifyingAreas.GetExtras();
            return View(areasModel);
        }

        [HttpPost]
        public IActionResult SubmitSortedItems([FromBody] Dictionary<string, string> userAreas)
        {
            //convert the array to a list
            var items = userAreas;

            //When the list is retrieved it has some extra characters so we need to remove them
            //List<string> extractedNumbers = userAreas
            //.Select(item =>
            //{
            //    // Match numbers (with optional period and exactly 2 digits after the period) followed by 3 letters
            //    MatchCollection matches = Regex.Matches(item, @"\d+(\.\d{2})? [A-Z]{3}");

            //    // Join the matched numbers into a single string
            //    return string.Join(" ", matches.Cast<Match>().Select(match => match.Value));
            //})
            //.ToList();

            //check the order of the items
            //var outcome = game.CheckOrder(extractedNumbers, callNumbers);
            var outcome = true;

            var result = "Lose";

            if (outcome)
            {
                result = "Win";
            }


            return Ok(result);
        }
    }
}
