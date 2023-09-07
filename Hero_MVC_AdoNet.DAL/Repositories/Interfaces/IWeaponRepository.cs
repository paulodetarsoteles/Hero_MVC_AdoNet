using Hero_MVC_AdoNet.Domain.Models;

namespace Hero_MVC_AdoNet.DAL.Repositories.Interfaces
{
    public interface IWeaponRepository
    {
        List<Weapon> GetAll();
        Weapon GetById(int id);
        bool Insert(Weapon weapon);
        bool Update(Weapon weapon);
        bool Delete(int weaponId);

        Hero GetHeroByWeaponId(int weaponId);
    }
}
