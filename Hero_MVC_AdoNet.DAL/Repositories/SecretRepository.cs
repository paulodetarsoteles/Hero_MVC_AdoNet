using Hero_MVC_AdoNet.DAL.Data;
using Hero_MVC_AdoNet.DAL.Repositories.Interfaces;
using Hero_MVC_AdoNet.Domain.Models;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;

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
            List<Secret> result = new();
            SqlCommand command = new("dbo.SecretGetAll");

            try
            {
                command.Connection = new SqlConnection(_connection.DefaultConnection);
                command.Connection.Open();
                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();

                if (!reader.Read())
                    return result;

                while (reader.Read())
                {
                    result.Add(new Secret
                    {
                        SecretId = Convert.ToInt32(reader["SecretId"]),
                        Name = reader["Name"].ToString(),
                        HeroId = Convert.ToInt32(reader["HeroId"])
                    });
                }

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Falha no repositório. {e.Message} - {e.StackTrace} - {DateTime.Now}");
                throw new Exception("Erro ao acessar as informações do banco de dados.");
            }
            finally
            {
                if (command.Connection.State == ConnectionState.Open)
                    command.Connection.Close();
            }
        }

        public Secret GetById(int secretId)
        {
            Secret result = new();
            SqlCommand command = new("dbo.SecretGetById");

            try
            {
                command.Connection = new SqlConnection(_connection.DefaultConnection);
                command.Connection.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@SecretId", SqlDbType.Int).Value = secretId;

                SqlDataReader reader = command.ExecuteReader();

                if (!reader.Read())
                    return result;

                result.SecretId = Convert.ToInt32(reader["SecretId"]);
                result.Name = reader["Name"].ToString();
                result.HeroId = Convert.ToInt32(reader["HeroId"]);

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Falha no repositório. {e.Message} - {e.StackTrace} - {DateTime.Now}");
                throw new Exception("Erro ao acessar as informações do banco de dados.");
            }
            finally
            {
                if (command.Connection.State == ConnectionState.Open)
                    command.Connection.Close();
            }
        }

        public bool Insert(Secret secret)
        {
            throw new NotImplementedException();
        }

        public bool Update(Secret secret)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int secretId)
        {
            throw new NotImplementedException();
        }
    }
}
