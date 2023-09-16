using System.ComponentModel.DataAnnotations;

namespace Hero_MVC_AdoNet.Web.ViewModels
{
    public class HeroMovieViewModel
    {
        public MovieViewModel MovieModel { get; set; }
        [Display(Name = "Heróis")]
        public List<HeroViewModel> HeroesModel { get; set; }
    }
}
