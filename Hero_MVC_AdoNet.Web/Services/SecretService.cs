using Hero_MVC_AdoNet.DAL.Repositories.Interfaces;
using Hero_MVC_AdoNet.Domain.Models;
using Hero_MVC_AdoNet.Web.Services.Interfaces;
using Hero_MVC_AdoNet.Web.ViewModels;

namespace Hero_MVC_AdoNet.Web.Services
{
    public class SecretService : ISecretService
    {
        private readonly IHeroRepository _heroRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly ISecretRepository _secretRepository;
        private readonly IWeaponRepository _weaponRepository;

        public SecretService(IHeroRepository heroRepository, IMovieRepository movieRepository, ISecretRepository secretRepository, IWeaponRepository weaponRepository)
        {
            _heroRepository = heroRepository;
            _movieRepository = movieRepository;
            _secretRepository = secretRepository;
            _weaponRepository = weaponRepository;
        }

        public List<SecretViewModel> GetAll()
        {
            try
            {
                List<SecretViewModel> result = new();
                List<Secret> secrets = _secretRepository.GetAll();

                foreach (Secret secret in secrets)
                    result.Add(new SecretViewModel
                    {
                        SecretId = secret.SecretId,
                        Name = secret.Name,
                        HeroId = secret.HeroId,
                        Hero = _heroRepository.GetById(secret.HeroId)
                    });

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e.Message} - {e.StackTrace} - {DateTime.Now}");
                throw new(e.Message);
            }
        }

        public SecretViewModel GetById(int id)
        {
            try
            {
                Secret secret = _secretRepository.GetById(id);

                if (secret is null)
                    return null;

                SecretViewModel result = new()
                {
                    SecretId = secret.SecretId,
                    Name = secret.Name,
                    HeroId = secret.HeroId,
                    Hero = _heroRepository.GetById(secret.HeroId)
                };

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e.Message} - {e.StackTrace} - {DateTime.Now}");
                throw new(e.Message);
            }
        }

        public bool Insert(SecretViewModel model)
        {
            try
            {
                Secret secret = new()
                {
                    SecretId = model.SecretId,
                    Name = model.Name, 
                    HeroId = model.HeroId
                };

                return _secretRepository.Insert(secret);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e.Message} - {e.StackTrace} - {DateTime.Now}");
                throw new(e.Message);
            }
        }

        public bool Update(SecretViewModel model)
        {
            try
            {
                Secret secret = new()
                {
                    SecretId = model.SecretId,
                    Name = model.Name,
                    HeroId = model.HeroId
                };

                return _secretRepository.Update(secret);
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
                Secret secret = _secretRepository.GetById(id) ?? throw new Exception("Identidade secreta não encontrada");

                return _secretRepository.Delete(id);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e.Message} - {e.StackTrace} - {DateTime.Now}");
                throw new(e.Message);
            }
        }

        #region Other Methods

        public List<HeroViewModel> GetAllHeroes()
        {
            try
            {
                List<HeroViewModel> result = new();
                List<Hero> heroes = _heroRepository.GetAll();

                foreach (Hero hero in heroes)
                    result.Add(new HeroViewModel
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
