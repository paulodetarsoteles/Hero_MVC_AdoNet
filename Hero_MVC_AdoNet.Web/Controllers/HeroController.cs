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

        public IActionResult Create()
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

                model.UpdateDate = DateTime.Now;

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

        public IActionResult Edit(int id)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(HeroViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("Por favor valide se as informações estão corretas.");

                model.UpdateDate = DateTime.Now;

                if (!_service.Update(model))
                    throw new Exception("Erro ao atualizar herói.");

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
                HeroViewModel model = _service.GetById(id);
                model ??= new();

                int relationsWithSecret = _service.VerifyRelationWithSecret(id);
                int relationsWithWeapons = _service.VerifyRelationWithWeapons(id);
                int relationsWithMovies = _service.VerifyRelationWithMovies(id);

                if (relationsWithSecret == 0 && relationsWithWeapons == 0 && relationsWithMovies == 0)
                    return View(model);

                string relationsMessage = "Verifique as relações antes de excluir o herói: ";

                if (relationsWithSecret != 0)
                    relationsMessage += $"{relationsWithSecret} relações com identidades secretas";

                if (relationsWithWeapons != 0)
                    relationsMessage += $" e {relationsWithWeapons} relações com armas/poderes";

                if (relationsWithMovies != 0)
                    relationsMessage += $" e {relationsWithMovies} relações com filmes";

                ModelState.AddModelError("", relationsMessage);
                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, HeroViewModel model)
        {
            try
            {
                bool result = _service.Delete(id);

                if (!result)
                    throw new Exception("Erro ao excluir herói, verifique as informações.");

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
