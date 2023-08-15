using Hero_MVC_AdoNet.DAL.Repositories.Interfaces;
using Hero_MVC_AdoNet.Domain.Models;

namespace Hero_MVC_AdoNet.DAL.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        public List<Movie> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Hero> GetAllHeroes()
        {
            throw new NotImplementedException();
        }

        public List<Hero> GetHeroes(int movieId)
        {
            throw new NotImplementedException();
        }

        public Secret GetById(int movieId)
        {
            throw new NotImplementedException();
        }

        public bool IsPresent(int movieId, int heroId)
        {
            throw new NotImplementedException();
        }

        public void Insert(Movie movie)
        {
            throw new NotImplementedException();
        }

        public void Update(Movie movie)
        {
            throw new NotImplementedException();
        }

        public void Delete(int movieId)
        {
            throw new NotImplementedException();
        }
    }
}
