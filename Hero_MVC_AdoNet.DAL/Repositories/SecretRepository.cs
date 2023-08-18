using Hero_MVC_AdoNet.DAL.Data;
using Hero_MVC_AdoNet.DAL.Repositories.Interfaces;
using Hero_MVC_AdoNet.Domain.Models;
using Microsoft.Extensions.Options;

namespace Hero_MVC_AdoNet.DAL.Repositories
{
    public class SecretRepository : ISecretRepository
    {
        private readonly ConnectionSetting _connection;

        public SecretRepository(IOptions<ConnectionSetting> connection)
        {
            _connection = connection.Value;
        }

        public List<Secret> GetAll()
        {
            throw new NotImplementedException();
        }

        public Secret GetById(int secretId)
        {
            throw new NotImplementedException();
        }

        public void Insert(Secret secret)
        {
            throw new NotImplementedException();
        }

        public void Update(Secret secret)
        {
            throw new NotImplementedException();
        }

        public void Delete(int secretId)
        {
            throw new NotImplementedException();
        }
    }
}
