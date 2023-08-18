using Hero_MVC_AdoNet.DAL.Data;
using Hero_MVC_AdoNet.DAL.Repositories.Interfaces;
using Hero_MVC_AdoNet.Domain.Models;
using Microsoft.Extensions.Options;

namespace Hero_MVC_AdoNet.DAL.Repositories
{
    public class HeroRepository : IHeroRepository
    {
        private readonly ConnectionSetting _connection;

        public HeroRepository(IOptions<ConnectionSetting> connection)
        {
            _connection = connection.Value;
        }

        public List<Hero> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Weapon> GetAllPowers()
        {
            throw new NotImplementedException();
        }

        public List<Secret> GetAllSecretIdentities()
        {
            throw new NotImplementedException();
        }

        public Hero GetById(int heroId)
        {
            throw new NotImplementedException();
        }

        public bool HasWeapon(int heroId)
        {
            throw new NotImplementedException();
        }

        public int CountFilms(int heroId)
        {
            throw new NotImplementedException();
        }

        public void Insert(Hero hero)
        {
            throw new NotImplementedException();
        }

        public void Update(Hero hero)
        {
            throw new NotImplementedException();
        }

        public void UpdatePowers(List<Weapon> weapons)
        {
            throw new NotImplementedException();
        }

        public void CleanPowers(int heroId)
        {
            throw new NotImplementedException();
        }

        public void Delete(int heroId)
        {
            throw new NotImplementedException();
        }
    }
}
