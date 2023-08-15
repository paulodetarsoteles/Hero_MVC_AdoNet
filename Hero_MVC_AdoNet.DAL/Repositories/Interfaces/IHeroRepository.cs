using Hero_MVC_AdoNet.Domain.Models;

namespace Hero_MVC_AdoNet.DAL.Repositories.Interfaces
{
    public interface IHeroRepository
    {
        List<Hero> GetAll();
        Hero GetById(int heroId);
        void Insert(Hero hero);
        void Update(Hero hero);
        void Delete(int heroId);

        List<Weapon> GetAllPowers();
        List<Secret> GetAllSecretIdentities();
        bool HasWeapon(int heroId);
        int CountFilms(int heroId);
        public void CleanPowers(int heroId);
        public void UpdatePowers(List<Weapon> weapons);
    }
}
