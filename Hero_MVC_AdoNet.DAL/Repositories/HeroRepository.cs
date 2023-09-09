using Hero_MVC_AdoNet.DAL.Data;
using Hero_MVC_AdoNet.DAL.Repositories.Interfaces;
using Hero_MVC_AdoNet.Domain.Models;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;

namespace Hero_MVC_AdoNet.DAL.Repositories
{
    public class HeroRepository : IHeroRepository
    {
        private readonly ConnectionSetting _connection;

        public HeroRepository(IOptions<ConnectionSetting> connection)
        {
            _connection = connection.Value;
        }

        public List<Hero> GetAll()
        {
            List<Hero> result = new();
            SqlCommand command = new("dbo.HeroGetAll");

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
                    result.Add(new Hero
                    {
                        HeroId = Convert.ToInt32(reader["HeroId"]),
                        Name = reader["Name"].ToString(),
                        Active = Convert.ToBoolean(reader["Active"]),
                        UpdateDate = Convert.ToDateTime(reader["UpdateDate"])
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

        public Hero GetById(int heroId)
        {
            Hero result = new();
            SqlCommand command = new("dbo.HeroGetById");

            try
            {
                command.Connection = new SqlConnection(_connection.DefaultConnection);
                command.Connection.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@HeroId", SqlDbType.Int).Value = heroId;

                SqlDataReader reader = command.ExecuteReader();

                if (!reader.Read())
                    return result;

                result.HeroId = Convert.ToInt32(reader["HeroId"]);
                result.Name = reader["Name"].ToString();
                result.Active = Convert.ToBoolean(reader["Active"]);
                result.UpdateDate = Convert.ToDateTime(reader["UpdateDate"]);

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

        public bool Insert(Hero hero)
        {
            SqlCommand command = new("dbo.HeroInsert");

            try
            {
                command.Connection = new SqlConnection(_connection.DefaultConnection);
                command.Connection.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@Name", SqlDbType.VarChar).Value = hero.Name;
                command.Parameters.Add("@Active", SqlDbType.Bit).Value = hero.Active;
                command.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = hero.UpdateDate;

                hero.HeroId = (int)command.ExecuteScalar();

                if (hero.HeroId == 0)
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

        public bool Update(Hero hero)
        {
            SqlCommand command = new("dbo.HeroUpdate");

            try
            {
                command.Connection = new SqlConnection(_connection.DefaultConnection);
                command.Connection.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@HeroId", SqlDbType.Int).Value = hero.HeroId;
                command.Parameters.Add("@Name", SqlDbType.VarChar).Value = hero.Name;
                command.Parameters.Add("@Active", SqlDbType.Bit).Value = hero.Active;
                command.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = hero.UpdateDate;

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

        public bool Delete(int heroId)
        {
            SqlCommand command = new("dbo.HeroDelete");

            try
            {
                command.Connection = new SqlConnection(_connection.DefaultConnection);
                command.Connection.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@HeroId", SqlDbType.Int).Value = heroId;

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
