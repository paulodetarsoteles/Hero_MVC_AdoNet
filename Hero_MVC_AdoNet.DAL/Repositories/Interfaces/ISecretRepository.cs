using Hero_MVC_AdoNet.Domain.Models;

namespace Hero_MVC_AdoNet.DAL.Repositories.Interfaces
{
    public interface ISecretRepository
    {
        List<Secret> GetAll();
        Secret GetById(int secretId);
        bool Insert(Secret secret);
        bool Update(Secret secret);
        bool Delete(int secretId);
    }
}
