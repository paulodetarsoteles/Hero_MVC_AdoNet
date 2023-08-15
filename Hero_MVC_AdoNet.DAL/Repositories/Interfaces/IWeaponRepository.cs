using Hero_MVC_AdoNet.Domain.Models;

namespace Hero_MVC_AdoNet.DAL.Repositories.Interfaces
{
    public interface IWeaponRepository
    {
        List<Weapon> GetAll();
        Weapon GetById(int id);
        void Insert(Weapon weapon);
        void Update(Weapon weapon);
        void Delete(int weaponId);

        Hero GetHero(int weaponId);
    }
}
