using Hero_MVC_AdoNet.DAL.Repositories.Interfaces;
using Hero_MVC_AdoNet.Domain.Models;
using Hero_MVC_AdoNet.Web.ViewModels;

namespace Hero_MVC_AdoNet.Web.Services
{
    public class WeaponService
    {
        private readonly IHeroRepository _heroRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly ISecretRepository _secretRepository;
        private readonly IWeaponRepository _weaponRepository;

        public WeaponService(IHeroRepository heroRepository, IMovieRepository movieRepository, ISecretRepository secretRepository, IWeaponRepository weaponRepository)
        {
            _heroRepository = heroRepository;
            _movieRepository = movieRepository;
            _secretRepository = secretRepository;
            _weaponRepository = weaponRepository;
        }

        public List<WeaponViewModel> GetAll()
        {
            try
            {
                List<WeaponViewModel> result = new();
                List<Weapon> weapons = _weaponRepository.GetAll();

                foreach (Weapon weapon in weapons)
                    result.Add(new WeaponViewModel
                    {
                        WeaponId = weapon.WeaponId,
                        Name = weapon.Name,
                        Type = weapon.Type,
                        HeroId = weapon.HeroId
                    });

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
