using LMS.Models;
using LMS_Management.IdentifyingAreas;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Controllers
{
    public class IdentifyingAreasController : Controller
    {
        private IdentifyingAreas identifyingAreas = new IdentifyingAreas();
        private Dictionary<string, string> levels = new Dictionary<string, string>();
        private static Dictionary<string, string> areas = new Dictionary<string, string>();
        private string mode = "";

        public ActionResult Index()
        {
            levels = identifyingAreas.GameLevelDescription();
            ViewBag.Levels = levels;

            //Check what the game mode is
            mode = HttpContext.Session.GetString("Mode");
            if (string.IsNullOrEmpty(mode))
            {
                mode = "Call Numbers to Description";
                HttpContext.Session.SetString("Mode", mode);
            }

            IdentifyingAreasModel areasModel = new IdentifyingAreasModel();
            areas = identifyingAreas.GenerateAreas(mode);
            areasModel.Areas = areas;
            areasModel.Extras = identifyingAreas.GetExtras();
            areasModel.Mode = mode;

            var keys = areas.Keys.ToList();
            var values = areas.Values.ToList();
            //Suffle the list including the extras
            if (mode == "Call Numbers to Description")
            {
                var shuffledKeys = keys.OrderBy(x => Guid.NewGuid()).ToList();
                areasModel.ShuffledKeys = shuffledKeys;

                values.AddRange(areasModel.Extras);
                var shuffledValues = values.OrderBy(x => Guid.NewGuid()).ToList();
                areasModel.ShuffledValues = shuffledValues;
                return View(areasModel);
            }
            else
            {
                var shuffledValues = values.OrderBy(x => Guid.NewGuid()).ToList();
                areasModel.ShuffledValues = shuffledValues;

                keys.AddRange(areasModel.Extras);
                var shuffledKeys = keys.OrderBy(x => Guid.NewGuid()).ToList();
                areasModel.ShuffledKeys = shuffledKeys;
                return View(areasModel);
            }



        }

        [HttpPost]
        public IActionResult SubmitSortedItems([FromBody] Dictionary<string, string> userAreas)
        {

            var outcome = identifyingAreas.CheckUserDictionary(areas, userAreas);

            var result = "Lose";

            if (outcome)
            {
                result = "Win";
            }
            ChangeMode();
            return Ok(result);
        }

        private void ChangeMode()
        {
            // Update the mode in the session
            mode = HttpContext.Session.GetString("Mode");
            if (mode == "Call Numbers to Description")
            {
                HttpContext.Session.SetString("Mode", "Descriptions to Call Numbers");
            }
            else
            {
                HttpContext.Session.SetString("Mode", "Call Numbers to Description");
            }


        }
    }
}
