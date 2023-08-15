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
        [Range(0, 10, ErrorMessage = "Digite uma nota entre 0 a 10 (sem vírgulas)")]
        public int Rate { get; set; }
    }
}
