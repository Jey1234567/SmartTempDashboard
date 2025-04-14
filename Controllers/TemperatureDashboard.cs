using Microsoft.AspNetCore.Mvc;

namespace SmartTempDashboard.Controllers
{
    public class TemperatureDashboard : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
