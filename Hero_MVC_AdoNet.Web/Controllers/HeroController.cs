using Hero_MVC_AdoNet.Web.Services;
using Hero_MVC_AdoNet.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hero_MVC_AdoNet.Web.Controllers
{
    public class HeroController : Controller
    {
        private readonly HeroService _service;

        public HeroController(HeroService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            List<HeroViewModel> modelList = new();
            modelList = _service.GetAll();

            return View(modelList);
        }

        public IActionResult Details(int id)
        {
            HeroViewModel model = new();
            model = _service.GetById(id);

            return View(model);
        }
    }
}
