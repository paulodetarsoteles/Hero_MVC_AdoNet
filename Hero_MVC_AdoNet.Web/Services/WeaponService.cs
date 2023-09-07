using Hero_MVC_AdoNet.DAL.Repositories.Interfaces;
using Hero_MVC_AdoNet.Domain.Models;
using Hero_MVC_AdoNet.Web.Services.Interfaces;
using Hero_MVC_AdoNet.Web.ViewModels;

namespace Hero_MVC_AdoNet.Web.Services
{
    public class WeaponService : IWeaponService
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

        public WeaponViewModel GetById(int id)
        {
            try
            {
                Weapon weapon = _weaponRepository.GetById(id);

                if (weapon is null)
                    return null;

                WeaponViewModel result = new();

                result.WeaponId = weapon.WeaponId;
                result.Name = weapon.Name;
                result.Type = weapon.Type;
                result.HeroId = weapon.HeroId;

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e.Message} - {e.StackTrace} - {DateTime.Now}");
                throw new(e.Message);
            }
        }

        public bool Insert(WeaponViewModel model)
        {
            try
            {
                Weapon weapon = new()
                {
                    WeaponId = model.WeaponId,
                    Name = model.Name,
                    Type = model.Type,
                    HeroId = model.HeroId
                };

                return _weaponRepository.Insert(weapon);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e.Message} - {e.StackTrace} - {DateTime.Now}");
                throw new(e.Message);
            }
        }

        public bool Update(WeaponViewModel model)
        {
            try
            {
                Weapon weapon = new()
                {
                    WeaponId = model.WeaponId,
                    Name = model.Name,
                    Type = model.Type,
                    HeroId = model.HeroId
                };

                return _weaponRepository.Update(weapon);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e.Message} = {e.StackTrace} - {DateTime.Now}");
                throw new(e.Message);
            }
        }

        public bool Delete(int id)
        {
            Weapon weapon = _weaponRepository.GetById(id) ?? throw new Exception("Arma/Poder não encontrada");

            return _weaponRepository.Delete(id);
        }

        #region Othor Methods

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

        #endregion
    }
}
