using Hero_MVC_AdoNet.Domain.Models;

namespace Hero_MVC_AdoNet.DAL.Repositories.Interfaces
{
    public interface IHeroRepository
    {
        List<Hero> GetAll();
        Hero GetById(int heroId);
        bool Insert(Hero hero);
        bool Update(Hero hero);
        bool Delete(int heroId);

        public int VerifyRelationWithSecret(int id);
        public int VerifyRelationWithWeapons(int id);
        public int VerifyRelationWithMovies(int id);
    }
}
