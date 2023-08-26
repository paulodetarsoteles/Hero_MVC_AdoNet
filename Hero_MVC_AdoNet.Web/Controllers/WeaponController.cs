using Microsoft.AspNetCore.Mvc;

namespace Hero_MVC_AdoNet.Web.Controllers
{
    public class WeaponController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
