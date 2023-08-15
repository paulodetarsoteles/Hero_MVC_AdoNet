using Hero_MVC_AdoNet.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Hero_MVC_AdoNet.Domain.Models
{
    public class Weapon
    {
        [Display(Name = "Código da Arma")]
        public int WeaponId { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Name { get; set; }

        [Display(Name = "Tipo de Arma")]
        public WeaponEnum Type { get; set; }

        [Display(Name = "Código do Herói")]
        public int HeroId { get; set; }
    }
}
