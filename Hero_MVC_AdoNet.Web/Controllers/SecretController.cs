using Microsoft.AspNetCore.Mvc;

namespace Hero_MVC_AdoNet.Web.Controllers
{
    public class SecretController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
