using Hero_MVC_AdoNet.DAL.Data;
using Hero_MVC_AdoNet.DAL.Repositories.Interfaces;
using Hero_MVC_AdoNet.Domain.Enum;
using Hero_MVC_AdoNet.Domain.Models;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;

namespace Hero_MVC_AdoNet.DAL.Repositories
{
    public class WeaponRepository : IWeaponRepository
    {
        private readonly ConnectionSetting _connection;

        public WeaponRepository(IOptions<ConnectionSetting> connection)
        {
            _connection = connection.Value;
        }

        public List<Weapon> GetAll()
        {
            List<Weapon> result = new();
            SqlCommand command = new("dbo.WeaponGetAll");

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
                    result.Add(new Weapon
                    {
                        WeaponId = Convert.ToInt32(reader["WeaponId"]),
                        Name = reader["Name"].ToString(),
                        Type = (WeaponEnum)Convert.ToInt16(reader["Type"]),
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

        public Weapon GetById(int weaponId)
        {
            Weapon result = new();
            SqlCommand command = new("dbo.WeaponGetById");

            try
            {
                command.Connection = new SqlConnection(_connection.DefaultConnection);
                command.Connection.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@WeaponId", SqlDbType.Int).Value = weaponId;

                SqlDataReader reader = command.ExecuteReader();

                if (!reader.Read())
                    return result;

                result.WeaponId = Convert.ToInt32(reader["WeaponId"]);
                result.Name = reader["Name"].ToString();
                result.Type = (WeaponEnum)Convert.ToInt16(reader["Type"]);
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

        public void Insert(Weapon weapon)
        {
            throw new NotImplementedException();
        }

        public void Update(Weapon weapon)
        {
            throw new NotImplementedException();
        }

        public void Delete(int weaponId)
        {
            throw new NotImplementedException();
        }

        #region SpecificMethods

        public Hero GetHeroByWeaponId(int weaponId)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
