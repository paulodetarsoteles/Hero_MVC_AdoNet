using Hero_MVC_AdoNet.DAL.Repositories.Interfaces;
using Hero_MVC_AdoNet.Domain.Models;
using Hero_MVC_AdoNet.Web.ViewModels;

namespace Hero_MVC_AdoNet.Web.Services
{
    public class HeroService
    {
        private readonly IHeroRepository _heroRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly ISecretRepository _secretRepository;
        private readonly IWeaponRepository _weaponRepository;

        public HeroService(IHeroRepository heroRepository, IMovieRepository movieRepository, ISecretRepository secretRepository, IWeaponRepository weaponRepository)
        {
            _heroRepository = heroRepository;
            _movieRepository = movieRepository;
            _secretRepository = secretRepository;
            _weaponRepository = weaponRepository;
        }

        public List<HeroViewModel> GetAll()
        {
            List<HeroViewModel> result = new();

            try
            {
                List<Hero> heroList = _heroRepository.GetAll();

                if (heroList.Count == 0)
                    return result;

                foreach (Hero hero in heroList)
                    result.Add(new HeroViewModel
                    {
                        HeroId = hero.HeroId,
                        Name = hero.Name,
                        Active = hero.Active,
                        UpdateDate = hero.UpdateDate
                    });
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e.Message} - {e.StackTrace} - {DateTime.Now}");
            }
            return result;
        }
    }
}
