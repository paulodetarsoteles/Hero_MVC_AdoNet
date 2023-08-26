using Hero_MVC_AdoNet.Web.ViewModels;

namespace Hero_MVC_AdoNet.Web.Services.Interfaces
{
    public interface ISecretService
    {
        List<SecretViewModel> GetAll();
        SecretViewModel GetById(int id);
    }
}
