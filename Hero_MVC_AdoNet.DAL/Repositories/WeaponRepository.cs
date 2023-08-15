using Hero_MVC_AdoNet.DAL.Repositories.Interfaces;
using Hero_MVC_AdoNet.Domain.Models;

namespace Hero_MVC_AdoNet.DAL.Repositories
{
    public class WeaponRepository : IWeaponRepository
    {
        public List<Weapon> GetAll()
        {
            throw new NotImplementedException();
        }

        public Weapon GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Hero GetHero(int weaponId)
        {
            throw new NotImplementedException();
        }

        public void Insert(Weapon weapon)
        {
            throw new NotImplementedException();
        }

        public void Update(Weapon weapon)
        {
            throw new NotImplementedException();
        }

        public void Delete(int weaponId)
        {
            throw new NotImplementedException();
        }
    }
}
