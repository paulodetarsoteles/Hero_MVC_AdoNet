using Hero_MVC_AdoNet.DAL.Data;
using Hero_MVC_AdoNet.DAL.Repositories.Interfaces;
using Hero_MVC_AdoNet.Domain.Models;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;
using System;

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
            finally
            {
                if (command.Connection.State == ConnectionState.Open)
                    command.Connection.Close();
            }
            return result;
        }

        public List<Weapon> GetAllPowers()
        {
            throw new NotImplementedException();
        }

        public List<Secret> GetAllSecretIdentities()
        {
            throw new NotImplementedException();
        }

        public Hero GetById(int heroId)
        {
            throw new NotImplementedException();
        }

        public bool HasWeapon(int heroId)
        {
            throw new NotImplementedException();
        }

        public int CountFilms(int heroId)
        {
            throw new NotImplementedException();
        }

        public void Insert(Hero hero)
        {
            throw new NotImplementedException();
        }

        public void Update(Hero hero)
        {
            throw new NotImplementedException();
        }

        public void UpdatePowers(List<Weapon> weapons)
        {
            throw new NotImplementedException();
        }

        public void CleanPowers(int heroId)
        {
            throw new NotImplementedException();
        }

        public void Delete(int heroId)
        {
            throw new NotImplementedException();
        }
    }
}
