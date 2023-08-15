using Hero_MVC_AdoNet.Domain.Models;

namespace Hero_MVC_AdoNet.DAL.Repositories.Interfaces
{
    public interface IMovieRepository
    {
        List<Movie> GetAll();
        Secret GetById(int movieId);
        void Insert(Movie movie);
        void Update(Movie movie);
        void Delete(int movieId);

        List<Hero> GetAllHeroes();
        List<Hero> GetHeroes(int movieId);
        bool IsPresent(int movieId, int heroId);
    }
}
