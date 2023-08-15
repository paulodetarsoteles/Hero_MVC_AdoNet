using System.ComponentModel.DataAnnotations;

namespace Hero_MVC_AdoNet.Domain.Models
{
    public class Hero
    {
        [Display(Name = "Código do Herói")]
        public int HeroId { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Name { get; set; }

        [Display(Name = "Ativo")]
        public bool Active { get; set; }

        [Display(Name = "Última atualização")]
        public DateTime UpdateDate { get; set; }
    }
}
