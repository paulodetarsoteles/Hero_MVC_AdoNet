using Hero_MVC_AdoNet.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Hero_MVC_AdoNet.Web.ViewModels
{
    public class HeroViewModel
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

        [Display(Name = "Id. Secreta")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public Secret Secret { get; set; }

        [Display(Name = "Armas")]
        public List<Weapon> Weapons { get; set; }

        public HeroViewModel() { }

        public HeroViewModel(string Name, bool Active, DateTime UpdateDate, Secret Secret, List<Weapon> Weapons, int HeroId = 0)
        {
            if (HeroId != 0)
                this.HeroId = HeroId;

            this.Name = Name;
            this.Active = Active;
            this.UpdateDate = UpdateDate;

            this.Secret = Secret;
            this.Weapons = Weapons;
        }
    }
}
