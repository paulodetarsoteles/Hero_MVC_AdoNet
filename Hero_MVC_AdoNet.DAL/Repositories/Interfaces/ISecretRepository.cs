using Hero_MVC_AdoNet.Domain.Models;

namespace Hero_MVC_AdoNet.DAL.Repositories.Interfaces
{
    public interface ISecretRepository
    {
        List<Secret> GetAll();
        Secret GetById(int secretId);
        void Insert(Secret secret);
        void Update(Secret secret);
        void Delete(int secretId);
    }
}
