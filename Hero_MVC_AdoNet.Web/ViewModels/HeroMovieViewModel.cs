namespace Hero_MVC_AdoNet.Web.ViewModels
{
    public class HeroMovieViewModel
    {
        public int HeroMovieId { get; set; }
        public int HeroId { get; set; }
        public int MovieId { get; set; }
        public HeroViewModel HeroModel { get; set; }
        public MovieViewModel MovieModel { get; set; }
    }
}
