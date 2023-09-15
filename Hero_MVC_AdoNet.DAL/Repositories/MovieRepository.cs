using Hero_MVC_AdoNet.DAL.Data;
using Hero_MVC_AdoNet.DAL.Repositories.Interfaces;
using Hero_MVC_AdoNet.Domain.Models;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;

namespace Hero_MVC_AdoNet.DAL.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ConnectionSetting _connection;

        public MovieRepository(IOptions<ConnectionSetting> connection)
        {
            _connection = connection.Value;
        }

        public List<Movie> GetAll()
        {
            List<Movie> result = new();
            SqlCommand command = new("dbo.MovieGetAll");

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
                    result.Add(new Movie
                    {
                        MovieId = Convert.ToInt32(reader["MovieId"]),
                        Name = reader["Name"].ToString(),
                        Rate = Convert.ToInt32(reader["Rate"])
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

        public Movie GetById(int movieId)
        {
            Movie result = new();
            SqlCommand command = new("dbo.MovieGetById");

            try
            {
                command.Connection = new SqlConnection(_connection.DefaultConnection);
                command.Connection.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@MovieId", SqlDbType.Int).Value = movieId;

                SqlDataReader reader = command.ExecuteReader();

                if (!reader.Read())
                    return result;

                result.MovieId = Convert.ToInt32(reader["MovieId"]);
                result.Name = reader["Name"].ToString();
                result.Rate = Convert.ToInt32(reader["Rate"]);

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

        public bool Insert(Movie movie)
        {
            SqlCommand command = new("dbo.MovieInsert");

            try
            {
                command.Connection = new SqlConnection(_connection.DefaultConnection);
                command.Connection.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@Name", SqlDbType.VarChar).Value = movie.Name;
                command.Parameters.Add("@Rate", SqlDbType.Int).Value = movie.Rate;

                movie.MovieId = (int)command.ExecuteScalar();

                if (movie.MovieId == 0)
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

        public bool Update(Movie movie)
        {
            SqlCommand command = new("dbo.MovieUpdate");

            try
            {
                command.Connection = new SqlConnection(_connection.DefaultConnection);
                command.Connection.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@MovieId", SqlDbType.Int).Value = movie.MovieId;
                command.Parameters.Add("@Name", SqlDbType.VarChar).Value = movie.Name;
                command.Parameters.Add("@Rate", SqlDbType.Int).Value = movie.Rate;

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

        public bool Delete(int movieId)
        {
            SqlCommand command = new("dbo.MovieDelete");

            try
            {
                command.Connection = new SqlConnection(_connection.DefaultConnection);
                command.Connection.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@MovieId", SqlDbType.Int).Value = movieId;

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

        #region Verify Relations

        public int VerifyRelationOfMovieWithHeroes(int id)
        {
            SqlCommand command = new("dbo.VerifyRelationOfMovieWithHeroes");

            try
            {
                command.Connection = new SqlConnection(_connection.DefaultConnection);
                command.Connection.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@MovieId", SqlDbType.Int).Value = id;

                return (int)command.ExecuteScalar();
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

        public List<Hero> GetHeroesByMovieId(int movieId)
        {
            List<Hero> result = new();
            SqlCommand command = new("dbo.GetHeroesByMovieId");

            try
            {
                command.Connection = new SqlConnection(_connection.DefaultConnection);
                command.Connection.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@MovieId", SqlDbType.Int).Value = movieId;

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

        public List<HeroMovie> GetHeroMovieByMovieId(int movieId)
        {
            List<HeroMovie> result = new();
            SqlCommand command = new("dbo.GetHeroMovieByMovieId");

            try
            {
                command.Connection = new SqlConnection(_connection.DefaultConnection);
                command.Connection.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@MovieId", SqlDbType.Int).Value = movieId;

                SqlDataReader reader = command.ExecuteReader();

                if (!reader.HasRows)
                    return result;

                while (reader.Read())
                {
                    result.Add(new HeroMovie
                    {
                        HeroId = Convert.ToInt32(reader["HeroId"]),
                        MovieId = Convert.ToInt32(reader["MovieId"])
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

        public bool AddRelationWithHero(HeroMovie heroMovie)
        {
            SqlCommand command = new("dbo.AddRelationWithHero");

            try
            {
                command.Connection = new SqlConnection(_connection.DefaultConnection);
                command.Connection.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@HeroId", SqlDbType.Int).Value = heroMovie.HeroId;
                command.Parameters.Add("@MovieId", SqlDbType.Int).Value = heroMovie.MovieId;

                if (command.ExecuteNonQuery() == 0)
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

        public void CleanMovieRelations(int movieId)
        {
            SqlCommand command = new("dbo.MovieHeroClean");

            try
            {
                command.Connection = new SqlConnection(_connection.DefaultConnection);
                command.Connection.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@MovieId", SqlDbType.Int).Value = movieId;

                command.ExecuteNonQuery();
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

        #endregion
    }
}
