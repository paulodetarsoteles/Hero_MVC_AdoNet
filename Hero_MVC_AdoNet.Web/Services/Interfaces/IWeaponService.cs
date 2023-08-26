using Hero_MVC_AdoNet.Web.ViewModels;

namespace Hero_MVC_AdoNet.Web.Services.Interfaces
{
    public interface IWeaponService
    {
        List<WeaponViewModel> GetAll();
        WeaponViewModel GetById(int id);
    }
}
