using Hero_MVC_AdoNet.DAL.Data;
using Hero_MVC_AdoNet.DAL.Repositories.Interfaces;
using Hero_MVC_AdoNet.Domain.Models;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using System.Data;
using Hero_MVC_AdoNet.Domain.Enum;

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
                {
                    if (command.Connection.State == ConnectionState.Open)
                        command.Connection.Close();

                    throw new Exception("Lista não encontrada.");
                }

                while (reader.Read())
                {
                    result.Add(new Secret
                    {
                        SecretId = Convert.ToInt32(reader["SecretId"]),
                        Name = reader["Name"].ToString(),
                        HeroId = Convert.ToInt32(reader["HeroId"])
                    });
                }
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
            return result;
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
                command.Parameters.Add("@WeaponId", SqlDbType.Int).Value = id;

                SqlDataReader reader = command.ExecuteReader();

                if (!reader.Read())
                {
                    if (command.Connection.State == ConnectionState.Open)
                        command.Connection.Close();

                    throw new Exception("Objeto não encontrado.");
                }

                result.SecretId = Convert.ToInt32(reader["SecretId"]);
                result.Name = reader["Name"].ToString();
                result.HeroId = Convert.ToInt32(reader["HeroId"]);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Falha no repositório. {e.Message} - {e.StackTrace} - {DateTime.Now}");
                throw new Exception("Erro ao acessar as informações do banco de dados.");
            }

            if (command.Connection.State == ConnectionState.Open)
                command.Connection.Close();

            return result;
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
