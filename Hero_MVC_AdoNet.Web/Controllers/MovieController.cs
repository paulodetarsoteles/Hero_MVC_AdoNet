using Hero_MVC_AdoNet.Web.Services;
using Hero_MVC_AdoNet.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hero_MVC_AdoNet.Web.Controllers
{
    public class MovieController : Controller
    {
        private readonly MovieService _service;

        public MovieController(MovieService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            List<MovieViewModel> modelList = new();
            modelList = _service.GetAll();

            return View(modelList);
        }
    }
}
