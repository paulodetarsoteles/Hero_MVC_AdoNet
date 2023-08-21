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
        bool HasWeaponByHeroId(int heroId);
        int CountFilmsByHeroId(int heroId);
        public void CleanPowersByHeroId(int heroId);
        public void UpdatePowersByHeroIdAndListWeaponId(int heroId, List<int> weaponsId);
    }
}
