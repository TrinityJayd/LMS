using LMS.Models;
using LMS_Management.IdentifyingAreas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Controllers
{
    public class IdentifyingAreasController : Controller
    {

        public ActionResult Index()
        {
            IdentifyingAreas identifyingAreas = new IdentifyingAreas();
            IdentifyingAreasModel areasModel = new IdentifyingAreasModel();
            areasModel.Areas = identifyingAreas.GenerateAreas("Call Numbers to Description");
            areasModel.Extras = identifyingAreas.GetExtras();
            return View(areasModel);
        }     
    }
}
