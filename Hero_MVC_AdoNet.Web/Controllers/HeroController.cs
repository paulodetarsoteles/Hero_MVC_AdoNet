using Hero_MVC_AdoNet.Web.Services.Interfaces;
using Hero_MVC_AdoNet.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hero_MVC_AdoNet.Web.Controllers
{
    public class HeroController : Controller
    {
        private readonly IHeroService _service;

        public HeroController(IHeroService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            try
            {
                List<HeroViewModel> modelList = _service.GetAll();
                modelList ??= new();

                return View(modelList);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        public IActionResult Details(int id)
        {
            try
            {
                HeroViewModel model = _service.GetById(id);
                model ??= new();

                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        public IActionResult Insert()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(HeroViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("Por favor valide se as informações estão corretas.");

                if (!_service.Insert(model))
                    throw new Exception("Erro ao inserir herói.");

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View(model);
            }
        }
    }
}
