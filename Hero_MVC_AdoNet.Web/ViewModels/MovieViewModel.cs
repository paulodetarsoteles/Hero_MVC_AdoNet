using Hero_MVC_AdoNet.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Hero_MVC_AdoNet.Web.ViewModels
{
    public class MovieViewModel
    {
        [Display(Name = "Código do Filme")]
        public int MovieId { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Name { get; set; }

        [Display(Name = "Nota")]
        [Range(0, 10, ErrorMessage = "Digite uma nota entre 0 a 10 (sem vírgulas)")]
        public int Rate { get; set; }

        [Display(Name = "Heróis")]
        public List<Hero> Heroes { get; set; }

        public MovieViewModel() { }

        public MovieViewModel(string Name, int Rate, List<Hero> Heroes, int MovieId = 0)
        {
            if (MovieId != 0)
                this.MovieId = MovieId;

            this.Name = Name;
            this.Rate = Rate;
            this.Heroes = Heroes;
        }
    }
}
