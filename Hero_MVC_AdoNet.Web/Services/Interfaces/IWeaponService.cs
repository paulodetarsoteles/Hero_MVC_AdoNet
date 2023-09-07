using Hero_MVC_AdoNet.Web.ViewModels;

namespace Hero_MVC_AdoNet.Web.Services.Interfaces
{
    public interface IWeaponService
    {
        List<WeaponViewModel> GetAll();
        WeaponViewModel GetById(int id);

        bool Insert(WeaponViewModel model);
        bool Update(WeaponViewModel model);
        bool Delete(int id);

        List<HeroDropDownViewModel> GetAllHeroes();
    }
}
