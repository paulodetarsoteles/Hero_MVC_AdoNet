using Hero_MVC_AdoNet.Web.ViewModels;

namespace Hero_MVC_AdoNet.Web.Services.Interfaces
{
    public interface IHeroService
    {
        List<HeroViewModel> GetAll();
        HeroViewModel GetById(int id);
        bool Insert(HeroViewModel model);
        bool Update(HeroViewModel model);
        bool Delete(int id);

        int VerifyRelationWithSecret(int id);
        int VerifyRelationWithWeapons(int id);
        int VerifyRelationWithMovies(int id);
    }
}
