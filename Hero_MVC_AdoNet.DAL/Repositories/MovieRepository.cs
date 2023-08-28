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

                if (!reader.Read())
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

        public void Insert(Movie movie)
        {
            throw new NotImplementedException();
        }

        public void Update(Movie movie)
        {
            throw new NotImplementedException();
        }

        public void Delete(int movieId)
        {
            throw new NotImplementedException();
        }

        #region SpecificMethods

        public List<Hero> GetAllHeroes()
        {
            throw new NotImplementedException();
        }

        public List<Hero> GetHeroesByMovieId(int movieId)
        {
            throw new NotImplementedException();
        }

        public bool IsPresentByMovieIdAndHeroId(int movieId, int heroId)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
