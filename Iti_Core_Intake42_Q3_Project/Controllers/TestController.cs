using Microsoft.AspNetCore.Mvc;

namespace Iti_Core_Intake42_Q3_Project.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return new JsonResult(new { ID = 1, Name = "hamada" });
        }
    }
}
