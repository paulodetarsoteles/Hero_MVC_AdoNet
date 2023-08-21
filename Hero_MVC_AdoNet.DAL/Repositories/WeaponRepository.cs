﻿using Hero_MVC_AdoNet.DAL.Data;
using Hero_MVC_AdoNet.DAL.Repositories.Interfaces;
using Hero_MVC_AdoNet.Domain.Models;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using System.Data;
using Hero_MVC_AdoNet.Domain.Enum;
using System.Xml.Linq;

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
                command.CommandType = CommandType.Text;

                SqlDataReader reader = command.ExecuteReader();

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

        public Weapon GetById(int id)
        {
            Weapon result = new();
            SqlCommand command = new("dbo.WeaponGetById");

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

                result.WeaponId = Convert.ToInt32(reader["WeaponId"]);
                result.Name = reader["Name"].ToString();
                result.Type = (WeaponEnum)Convert.ToInt16(reader["Type"]);
                result.HeroId = Convert.ToInt32(reader["HeroId"]);
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

        public Hero GetHero(int weaponId)
        {
            throw new NotImplementedException();
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
    }
}
