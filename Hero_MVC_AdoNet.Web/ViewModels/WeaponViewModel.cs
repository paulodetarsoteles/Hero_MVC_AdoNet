using Hero_MVC_AdoNet.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Hero_MVC_AdoNet.Web.ViewModels
{
    public class WeaponViewModel
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

        public WeaponViewModel() { }

        public WeaponViewModel(string Name, WeaponEnum Type, int HeroId, int WeaponId = 0)
        {
            if (WeaponId != 0)
                this.WeaponId = WeaponId;

            this.Name = Name;
            this.Type = Type;
            this.HeroId = HeroId;
            this.WeaponId = WeaponId;
        }
    }
}
