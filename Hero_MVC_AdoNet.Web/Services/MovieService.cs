using Hero_MVC_AdoNet.DAL.Repositories.Interfaces;
using Hero_MVC_AdoNet.Domain.Models;
using Hero_MVC_AdoNet.Web.Services.Interfaces;
using Hero_MVC_AdoNet.Web.ViewModels;

namespace Hero_MVC_AdoNet.Web.Services
{
    public class MovieService : IMovieService
    {
        private readonly IHeroRepository _heroRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly ISecretRepository _secretRepository;
        private readonly IWeaponRepository _weaponRepository;

        public MovieService(IHeroRepository heroRepository, IMovieRepository movieRepository, ISecretRepository secretRepository, IWeaponRepository weaponRepository)
        {
            _heroRepository = heroRepository;
            _movieRepository = movieRepository;
            _secretRepository = secretRepository;
            _weaponRepository = weaponRepository;
        }

        public List<MovieViewModel> GetAll()
        {
            try
            {
                List<Movie> movies = _movieRepository.GetAll();

                if (movies.Count == 0)
                    return null;

                List<MovieViewModel> result = new();

                foreach (Movie movie in movies)
                    result.Add(new MovieViewModel
                    {
                        MovieId = movie.MovieId,
                        Name = movie.Name,
                        Rate = movie.Rate
                    });

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e.Message} - {e.StackTrace} - {DateTime.Now}");
                throw new(e.Message);
            }
        }

        public MovieViewModel GetById(int id)
        {
            try
            {
                Movie movie = _movieRepository.GetById(id);

                if (movie is null) 
                    return null;

                MovieViewModel result = new();

                result.MovieId = movie.MovieId;
                result.Name = movie.Name;
                result.Rate = movie.Rate;

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e.Message} - {e.StackTrace} - {DateTime.Now}");
                throw new(e.Message);
            }
        }
    }
}
