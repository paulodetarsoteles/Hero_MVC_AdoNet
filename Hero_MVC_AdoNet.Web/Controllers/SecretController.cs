using Hero_MVC_AdoNet.Web.Services;
using Hero_MVC_AdoNet.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hero_MVC_AdoNet.Web.Controllers
{
    public class SecretController : Controller
    {
        private readonly SecretService _service;

        public SecretController(SecretService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            List<SecretViewModel> modelList = new();
            modelList = _service.GetAll();

            return View(modelList);
        }
    }
}
