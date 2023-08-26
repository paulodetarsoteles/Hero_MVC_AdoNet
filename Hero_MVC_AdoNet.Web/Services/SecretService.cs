using Hero_MVC_AdoNet.DAL.Repositories.Interfaces;
using Hero_MVC_AdoNet.Domain.Models;
using Hero_MVC_AdoNet.Web.ViewModels;

namespace Hero_MVC_AdoNet.Web.Services
{
    public class SecretService
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
                        HeroId = secret.HeroId
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

                SecretViewModel result = new();

                result.SecretId = secret.SecretId;
                result.Name = secret.Name;
                result.HeroId = secret.HeroId;

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
