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

        public IActionResult UpdateRelationsWithHero(int id)
        {
            try
            {
                ViewBag.GetAllHeroes = new SelectList(_service.GetAllHeroes(), "HeroId", "Name");

                HeroMovieViewModel model = _service.GetHeroMovieByMovieId(id);

                model ??= new();

                model.HeroesModel ??= new();

                return View(model);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateRelationsWithHero(HeroMovieViewModel model)
        {
            try
            {
                ViewBag.GetAllHeroes = new SelectList(_service.GetAllHeroes(), "HeroId", "Name");

                string heroesId = Request.Form["chkHero"].ToString();

                if (!string.IsNullOrEmpty(heroesId))
                {
                    int[] splitHeroes = heroesId.Split(',').Select(int.Parse).ToArray();

                    if (splitHeroes.Length > 0)
                    {
                        List<HeroViewModel> listHeroModels = new();
                        model.HeroesModel = new();

                        foreach (int heroId in splitHeroes)
                        {
                            HeroViewModel heroViewModel = _service.GetHeroById(heroId);
                            listHeroModels.Add(heroViewModel);
                        }

                        model.HeroesModel.AddRange(listHeroModels);
                    }
                }

                bool result = _service.UpdateRelationsWithHero(model);

                if (!result)
                    throw new Exception("Erro ao vincular filme com heróis.");

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View(_service.GetHeroMovieByMovieId(model.MovieModel.MovieId));
            }
        }
    }
}
