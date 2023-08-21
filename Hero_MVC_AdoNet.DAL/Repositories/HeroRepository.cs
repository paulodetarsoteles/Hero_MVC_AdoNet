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
                command.CommandType = CommandType.Text;

                SqlDataReader reader = command.ExecuteReader();

                if (!reader.Read())
                {
                    if (command.Connection.State == ConnectionState.Open)
                        command.Connection.Close();

                    throw new Exception("Lista não encontrada.");
                }

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

        public Hero GetById(int heroId)
        {
            Hero result = new();
            SqlCommand command = new("dbo.MovieGetById");

            try
            {
                command.Connection = new SqlConnection(_connection.DefaultConnection);
                command.Connection.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@HeroId", SqlDbType.Int).Value = heroId;

                SqlDataReader reader = command.ExecuteReader();

                if (!reader.Read())
                {
                    if (command.Connection.State == ConnectionState.Open)
                        command.Connection.Close();

                    throw new Exception("Objeto não encontrado.");
                }

                result.HeroId = Convert.ToInt32(reader["HeroId"]);
                result.Name = reader["Name"].ToString();
                result.Active = Convert.ToBoolean(reader["Active"]);
                result.UpdateDate = Convert.ToDateTime(reader["UpdateDate"]);
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

        public void Insert(Hero hero)
        {
            throw new NotImplementedException();
        }

        public void Update(Hero hero)
        {
            throw new NotImplementedException();
        }

        public void Delete(int heroId)
        {
            throw new NotImplementedException();
        }

        #region SpecificMethods

        public List<Weapon> GetAllPowers()
        {
            throw new NotImplementedException();
        }

        public List<Secret> GetAllSecretIdentities()
        {
            throw new NotImplementedException();
        }

        public bool HasWeaponByHeroId(int heroId)
        {
            throw new NotImplementedException();
        }

        public int CountFilmsByHeroId(int heroId)
        {
            throw new NotImplementedException();
        }

        public void CleanPowersByHeroId(int heroId)
        {
            throw new NotImplementedException();
        }

        public void UpdatePowersByHeroIdAndListWeaponId(int heroId, List<int> weaponsId)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
