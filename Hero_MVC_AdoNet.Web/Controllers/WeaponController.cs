using Hero_MVC_AdoNet.Web.Services.Interfaces;
using Hero_MVC_AdoNet.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hero_MVC_AdoNet.Web.Controllers
{
    public class WeaponController : Controller
    {
        private readonly IWeaponService _service;

        public WeaponController(IWeaponService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            List<WeaponViewModel> modelList = new();
            modelList = _service.GetAll();

            return View(modelList);
        }

        public IActionResult Details(int id)
        {
            WeaponViewModel model = new();
            model = _service.GetById(id);

            return View(model);
        }
    }
}
