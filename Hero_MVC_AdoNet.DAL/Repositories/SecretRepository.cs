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

                if (!reader.HasRows)
                    return result;

                while (reader.Read())
                {
                    Secret secret = new()
                    {
                        SecretId = Convert.ToInt32(reader["SecretId"]),
                        Name = reader["Name"].ToString()
                    };

                    try
                    {
                        secret.HeroId = Convert.ToInt32(reader["HeroId"]);
                    }
                    catch
                    {
                        secret.HeroId = 0;
                    }

                    result.Add(secret);
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

                try
                {
                    result.HeroId = Convert.ToInt32(reader["HeroId"]);
                }
                catch
                {
                    result.HeroId = 0;
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

        public bool Insert(Secret secret)
        {
            SqlCommand command = new("dbo.SecretInsert");

            try
            {
                command.Connection = new SqlConnection(_connection.DefaultConnection);
                command.Connection.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@Name", SqlDbType.VarChar).Value = secret.Name;
                command.Parameters.Add("@HeroId", SqlDbType.Int).Value = secret.HeroId;

                secret.SecretId = (int)command.ExecuteScalar();

                if (secret.SecretId == 0)
                    return false;

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Falha no repositório. {e.Message} - {e.StackTrace} - {DateTime.Now}");
                throw new Exception("Erro ao inserir entidade no banco de dados.");
            }
            finally
            {
                if (command.Connection.State == ConnectionState.Open)
                    command.Connection.Close();
            }
        }

        public bool Update(Secret secret)
        {
            SqlCommand command = new("dbo.SecretUpdate");

            try
            {
                command.Connection = new SqlConnection(_connection.DefaultConnection);
                command.Connection.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@SecretId", SqlDbType.Int).Value = secret.SecretId;
                command.Parameters.Add("@Name", SqlDbType.VarChar).Value = secret.Name;
                command.Parameters.Add("@HeroId", SqlDbType.Int).Value = secret.HeroId;

                int rows = command.ExecuteNonQuery();

                if (rows == 0)
                    return false;

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Falha no repositório. {e.Message} - {e.StackTrace} - {DateTime.Now}");
                throw new Exception("Erro ao atualizar entidade no banco de dados.");
            }
            finally
            {
                if (command.Connection.State == ConnectionState.Open)
                    command.Connection.Close();
            }
        }

        public bool Delete(int secretId)
        {
            SqlCommand command = new("dbo.SecretDelete");

            try
            {
                command.Connection = new SqlConnection(_connection.DefaultConnection);
                command.Connection.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@SecretId", SqlDbType.Int).Value = secretId;

                int rows = command.ExecuteNonQuery();

                if (rows == 0)
                    return false;

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Falha no repositório. {e.Message} - {e.StackTrace} - {DateTime.Now}");
                throw new Exception("Erro ao atualizar entidade no banco de dados.");
            }
            finally
            {
                if (command.Connection.State == ConnectionState.Open)
                    command.Connection.Close();
            }
        }
    }
}
