using Hero_MVC_AdoNet.Domain.Models;

namespace Hero_MVC_AdoNet.DAL.Repositories.Interfaces
{
    public interface IMovieRepository
    {
        List<Movie> GetAll();
        Movie GetById(int movieId);
        bool Insert(Movie movie);
        bool Update(Movie movie);
        bool Delete(int movieId);

        int VerifyRelationOfMovieWithHeroes(int id);
        List<Hero> GetHeroesByMovieId(int movieId);
        bool AddRelationWithHero(HeroMovie heroMovie);
    }
}
