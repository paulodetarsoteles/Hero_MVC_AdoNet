using Hero_MVC_AdoNet.Web.ViewModels;

namespace Hero_MVC_AdoNet.Web.Services.Interfaces
{
    public interface IMovieService
    {
        List<MovieViewModel> GetAll();
        MovieViewModel GetById(int id);
        bool Insert(MovieViewModel model);
        bool Update(MovieViewModel model);
        bool Delete(int id);
    }
}
