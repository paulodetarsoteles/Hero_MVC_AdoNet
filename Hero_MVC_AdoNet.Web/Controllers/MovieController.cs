using Hero_MVC_AdoNet.Web.Services.Interfaces;
using Hero_MVC_AdoNet.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
            List<MovieViewModel> modelList = new();
            modelList = _service.GetAll();

            return View(modelList);
        }

        public IActionResult Details(int id)
        {
            MovieViewModel model = new();
            model = _service.GetById(id);

            return View(model);
        }
    }
}
