using Hero_MVC_AdoNet.Web.ViewModels;

namespace Hero_MVC_AdoNet.Web.Services.Interfaces
{
    public interface ISecretService
    {
        List<SecretViewModel> GetAll();
        SecretViewModel GetById(int id);
        bool Insert(SecretViewModel model);
        bool Update(SecretViewModel model);
        bool Delete(int id);
    }
}
