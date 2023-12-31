﻿using Hero_MVC_AdoNet.DAL.Data;
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

                if (!reader.HasRows)
                    return result;

                while (reader.Read())
                {
                    Weapon weapon = new()
                    {
                        WeaponId = Convert.ToInt32(reader["WeaponId"]),
                        Name = reader["Name"].ToString(),
                        Type = (WeaponEnum)Convert.ToInt16(reader["Type"])
                    };

                    try
                    {
                        weapon.HeroId = Convert.ToInt32(reader["HeroId"]);
                    }
                    catch
                    {
                        weapon.HeroId = null;
                    }

                    result.Add(weapon);
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

                try
                {
                    result.HeroId = Convert.ToInt32(reader["HeroId"]);
                }
                catch
                {
                    result.HeroId = null;
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

        public bool Insert(Weapon weapon)
        {
            SqlCommand command = new("dbo.WeaponInsert");

            try
            {
                command.Connection = new SqlConnection(_connection.DefaultConnection);
                command.Connection.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@Name", SqlDbType.VarChar).Value = weapon.Name;
                command.Parameters.Add("@Type", SqlDbType.Int).Value = weapon.Type;
                command.Parameters.Add("HeroId", SqlDbType.Int).Value = weapon.HeroId;

                weapon.WeaponId = (int)command.ExecuteScalar();

                if (weapon.WeaponId == 0)
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

        public bool Update(Weapon weapon)
        {
            SqlCommand command = new("dbo.WeaponUpdate");

            try
            {
                command.Connection = new SqlConnection(_connection.DefaultConnection);
                command.Connection.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@WeaponId", SqlDbType.Int).Value = weapon.WeaponId;
                command.Parameters.Add("@Name", SqlDbType.VarChar).Value = weapon.Name;
                command.Parameters.Add("@Type", SqlDbType.Int).Value = weapon.Type;
                command.Parameters.Add("@HeroId", SqlDbType.Int).Value = weapon.HeroId;

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

        public bool Delete(int weaponId)
        {
            SqlCommand command = new("dbo.WeaponDelete");

            try
            {
                command.Connection = new SqlConnection(_connection.DefaultConnection);
                command.Connection.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@WeaponId", SqlDbType.Int).Value = weaponId;

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

        #region SpecificMethods

        public Hero GetHeroByWeaponId(int weaponId)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
