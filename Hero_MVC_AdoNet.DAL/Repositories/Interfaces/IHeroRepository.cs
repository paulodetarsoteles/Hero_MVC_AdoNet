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

        int VerifyRelationWithSecret(int id);
        int VerifyRelationWithWeapons(int id);
        int VerifyRelationWithMovies(int id);
    }
}
