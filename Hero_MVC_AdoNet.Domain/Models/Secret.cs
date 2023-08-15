using System.ComponentModel.DataAnnotations;

namespace Hero_MVC_AdoNet.Domain.Models
{
    public class Secret
    {
        [Display(Name = "Código da Id. Secreta")]
        public int SecretId { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Name { get; set; }

        [Display(Name = "Código do Herói")]
        public int HeroId { get; set; }
    }
}
