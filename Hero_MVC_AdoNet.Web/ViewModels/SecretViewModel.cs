using Hero_MVC_AdoNet.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Hero_MVC_AdoNet.Web.ViewModels
{
    public class SecretViewModel
    {
        [Display(Name = "Código da Id. Secreta")]
        public int SecretId { get; set; }

        [Display(Name = "Identidade Secreta")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Name { get; set; }

        [Display(Name = "Código do Herói")]
        public int? HeroId { get; set; }

        [Display(Name = "Herói")]
        public Hero Hero { get; set; }

        public SecretViewModel() { }
    }
}
