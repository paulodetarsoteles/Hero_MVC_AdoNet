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
    }
}
