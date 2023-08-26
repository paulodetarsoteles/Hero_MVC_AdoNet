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
            List<SecretViewModel> modelList = new();
            modelList = _service.GetAll();

            return View(modelList);
        }

        public IActionResult Details(int id)
        {
            SecretViewModel model = new();
            model = _service.GetById(id);

            return View(model);
        }
    }
}
