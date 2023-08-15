using System.ComponentModel.DataAnnotations;

namespace Hero_MVC_AdoNet.Domain.Models
{
    public class Movie
    {
        [Display(Name = "Código do Filme")]
        public int MovieId { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Name { get; set; }

        [Display(Name = "Nota")]
        public int Rate { get; set; }
    }
}
