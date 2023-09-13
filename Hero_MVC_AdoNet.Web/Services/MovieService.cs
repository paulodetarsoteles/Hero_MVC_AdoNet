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

                int relations = _movieRepository.VerifyRelationOfMovieWithHeroes(id);

                if (relations == 0)
                    return result;

                List<Hero> heroes = _movieRepository.GetHeroesByMovieId(id);

                foreach (Hero hero in heroes)
                {
                    HeroViewModel model = new HeroViewModel()
                    {
                        HeroId = hero.HeroId,
                        Name = hero.Name
                    };

                    result.Heroes.Add(model);
                }

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e.Message} - {e.StackTrace} - {DateTime.Now}");
                throw new(e.Message);
            }
        }

        public bool Insert(MovieViewModel model)
        {
            try
            {
                Movie movie = new()
                {
                    MovieId = model.MovieId,
                    Name = model.Name,
                    Rate = model.Rate
                };

                return _movieRepository.Insert(movie);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e.Message} - {e.StackTrace} - {DateTime.Now}");
                throw new(e.Message);
            }
        }

        public bool Update(MovieViewModel model)
        {
            try
            {
                Movie movie = new()
                {
                    MovieId = model.MovieId,
                    Name = model.Name,
                    Rate = model.Rate
                };

                return _movieRepository.Update(movie);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e.Message} - {e.StackTrace} - {DateTime.Now}");
                throw new(e.Message);
            }
        }

        public bool Delete(int id)
        {
            try
            {
                Movie movie = _movieRepository.GetById(id) ?? throw new Exception("Filme não encontrado");

                return _movieRepository.Delete(id);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e.Message} - {e.StackTrace} - {DateTime.Now}");
                throw new(e.Message);
            }
        }

        #region Other Methods

        public int VerifyRelationOfMovieWithHeroes(int id)
        {
            try
            {
                return _movieRepository.VerifyRelationOfMovieWithHeroes(id);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e.Message} - {e.StackTrace} - {DateTime.Now}");
                throw new(e.Message);
            }
        }

        public List<HeroDropDownViewModel> GetAllHeroes()
        {
            try
            {
                List<HeroDropDownViewModel> result = new();
                List<Hero> heroes = _heroRepository.GetAll();

                foreach (Hero hero in heroes)
                    result.Add(new HeroDropDownViewModel
                    {
                        HeroId = hero.HeroId,
                        Name = hero.Name
                    });

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e.Message} - {e.StackTrace} - {DateTime.Now}");
                throw new(e.Message);
            }
        }

        public HeroMovieViewModel GetHeroMovieByMovieId(int movieId)
        {
            try
            {
                List<HeroMovie> heroesMovie = _movieRepository.GetHeroMovieByMovieId(movieId);

                HeroMovieViewModel result = new();

                if (heroesMovie is null)
                    return result;

                Movie movie = _movieRepository.GetById(movieId);

                MovieViewModel movieViewModel = new()
                {
                    MovieId = movie.MovieId,
                    Name = movie.Name
                };

                foreach (HeroMovie heroMovie in heroesMovie)
                {
                    Hero hero = _heroRepository.GetById(heroMovie.HeroId);

                    HeroViewModel heroViewModel = new()
                    {
                        HeroId = hero.HeroId,
                        Name = hero.Name
                    };

                    result.HeroesModel.Add(heroViewModel);
                }

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e.Message} - {e.StackTrace} - {DateTime.Now}");
                throw new(e.Message);
            }
        }

        public bool UpdateRelationsWithHero(HeroMovieViewModel model)
        {
            try
            {
                if (model.HeroesModel is null)
                {
                    _movieRepository.CleanMovieRelations(model.MovieModel.MovieId);
                    return true;
                }

                _movieRepository.CleanMovieRelations(model.MovieModel.MovieId);

                foreach (HeroViewModel heroViewModel in model.HeroesModel)
                {
                    HeroMovie heroMovie = new()
                    {
                        HeroId = model.MovieModel.MovieId,
                        MovieId = heroViewModel.HeroId
                    };

                    if (!_movieRepository.AddRelationWithHero(heroMovie))
                        return false;
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e.Message} - {e.StackTrace} - {DateTime.Now}");
                throw new(e.Message);
            }
        }

        #endregion
    }
}
