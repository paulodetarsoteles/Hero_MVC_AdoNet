using Hero_MVC_AdoNet.Web.Services.Interfaces;
using Hero_MVC_AdoNet.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hero_MVC_AdoNet.Web.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _service;

        public MovieController(IMovieService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            try
            {
                List<MovieViewModel> modelList = _service.GetAll();
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
                MovieViewModel model = _service.GetById(id);
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
        public IActionResult Create(MovieViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("Por favor valide se as informações estão corretas.");

                if (!_service.Insert(model))
                    throw new Exception("Erro ao inserir filme.");

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
                MovieViewModel model = _service.GetById(id);
                model ??= new();

                return View(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(MovieViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("Por favor valide se as informações estão corretas.");

                if (!_service.Update(model))
                    throw new Exception("Erro ao atualizar filme.");

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
                MovieViewModel model = _service.GetById(id);
                model ??= new();

                int relationWithHeroes = _service.VerifyRelationOfMovieWithHeroes(id);

                if (relationWithHeroes == 0)
                    return View(model);

                string relationsMessage = $"Verifique as relações antes de excluir o filme: {relationWithHeroes} relações com heróis";

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
        public IActionResult Delete(int id, MovieViewModel model)
        {
            try
            {
                bool result = _service.Delete(id);

                if (!result)
                    throw new Exception("Erro ao excluir filme, verifique as informações.");

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View(_service.GetById(id));
            }
        }

        public IActionResult AddRelationWithHero(int movieId) 
        {
            try
            {
                ViewBag.GetAllHeroes = new SelectList(_service.GetAllHeroes(), "HeroId", "Name");

                MovieViewModel model = _service.GetById(movieId);
                model ??= new();

                return View(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddRelationWithHero(HeroMovieViewModel model)
        {
            try
            {
                ViewBag.GetAllHeroes = new SelectList(_service.GetAllHeroes(), "HeroId", "Name");

                HeroMovieViewModel model = 

                return View(model);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
