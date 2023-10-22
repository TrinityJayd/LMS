using LMS.Models;
using LMS_Management.IdentifyingAreas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging.Rules;
using System.Text.RegularExpressions;

namespace LMS.Controllers
{
    public class IdentifyingAreasController : Controller
    {
        private IdentifyingAreas identifyingAreas = new IdentifyingAreas();
        private Dictionary<string, string> levels = new Dictionary<string, string>();
        private static Dictionary<string, string>  areas = new Dictionary<string, string>();
        private string mode = "";

        public ActionResult Index()
        {
            levels = identifyingAreas.GameLevelDescription();
            ViewBag.Levels = levels;

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
            
            return View(areasModel);
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
