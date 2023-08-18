using Hero_MVC_AdoNet.DAL.Data;
using Hero_MVC_AdoNet.DAL.Repositories.Interfaces;
using Hero_MVC_AdoNet.Domain.Models;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using System.Data;

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
                command.CommandType = CommandType.Text;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(new Movie
                    {
                        MovieId = Convert.ToInt32(reader["MovieId"]),
                        Name = reader["Name"].ToString(),
                        Rate = Convert.ToInt32(reader["Rate"])
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

        public List<Hero> GetAllHeroes()
        {
            throw new NotImplementedException();
        }

        public List<Hero> GetHeroes(int movieId)
        {
            throw new NotImplementedException();
        }

        public Secret GetById(int movieId)
        {
            throw new NotImplementedException();
        }

        public bool IsPresent(int movieId, int heroId)
        {
            throw new NotImplementedException();
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
    }
}
