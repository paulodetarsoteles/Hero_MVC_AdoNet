using Hero_MVC_AdoNet.Web.Services.Interfaces;
using Hero_MVC_AdoNet.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection;

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
            try
            {
                List<WeaponViewModel> modelList = _service.GetAll();
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
                WeaponViewModel model = _service.GetById(id);
                model ??= new();

                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        public IActionResult Create()
        {
            try
            {
                ViewBag.GetAllHeroes = new SelectList(_service.GetAllHeroes(), "HeroId", "Name");

                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(WeaponViewModel model) 
        {
            try
            {
                ViewBag.GetAllHeroes = new SelectList(_service.GetAllHeroes(), "HeroId", "Name");

                if (!ModelState.IsValid)
                    throw new Exception("Por favor valide se as informações estão corretas.");

                if (!_service.Insert(model))
                    throw new Exception("Erro ao inserir arma/poder.");

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View(model);
            }
        }

        public IActionResult Edit(int id)
        {
            try
            {
                ViewBag.GetAllHeroes = new SelectList(_service.GetAllHeroes(), "HeroId", "Name");

                WeaponViewModel model = _service.GetById(id);
                model ??= new();

                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(WeaponViewModel model)
        {
            try
            {
                ViewBag.GetAllHeroes = new SelectList(_service.GetAllHeroes(), "HeroId", "Name");

                if (!ModelState.IsValid)
                    throw new Exception("Por favor valide se as informações estão corretas.");

                if (!_service.Update(model))
                    throw new Exception("Erro ao atualizar arma/poder.");

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View(model);
            }
        }

        public IActionResult Delete(int id)
        {
            try
            {
                WeaponViewModel model = _service.GetById(id);
                model ??= new();

                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, WeaponViewModel model)
        {
            try
            {
                bool result = _service.Delete(id);

                if (!result)
                    throw new Exception("Erro ao excluir arma/poder, verifique as informações.");

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View(_service.GetById(id));
            }
        }
    }
}
