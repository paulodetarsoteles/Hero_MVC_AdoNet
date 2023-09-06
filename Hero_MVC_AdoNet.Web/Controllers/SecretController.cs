using Hero_MVC_AdoNet.Web.Services.Interfaces;
using Hero_MVC_AdoNet.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hero_MVC_AdoNet.Web.Controllers
{
    public class SecretController : Controller
    {
        private readonly ISecretService _service;

        public SecretController(ISecretService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            try
            {
                List<SecretViewModel> modelList = _service.GetAll();
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
                SecretViewModel model = _service.GetById(id);
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
        public IActionResult Create(SecretViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("Por favor valide se as informações estão corretas.");

                if (!_service.Insert(model))
                    throw new Exception("Erro ao inserir identidade secreta.");

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
                SecretViewModel model = _service.GetById(id);
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
        public IActionResult Edit(SecretViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("Por favor valide se as informações estão corretas.");

                if (!_service.Update(model))
                    throw new Exception("Erro ao atualizar identidade secreta.");

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
                SecretViewModel model = _service.GetById(id);
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
        public IActionResult Delete(int id, SecretViewModel model)
        {
            try
            {
                bool result = _service.Delete(id);

                if (!result)
                    throw new Exception("Erro ao excluir identidade secreta, verifique as informações.");

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
