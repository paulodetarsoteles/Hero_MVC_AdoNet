using Hero_MVC_AdoNet.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Hero_MVC_AdoNet.Web.ViewModels
{
    public class SecretViewModel
    {
        [Display(Name = "Código da Id. Secreta")]
        public int SecretId { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Name { get; set; }

        [Display(Name = "Código do Herói")]
        public int HeroId { get; set; }

        [Display(Name = "Herói")]
        public Hero Hero { get; set; }

        public SecretViewModel() { }

        public SecretViewModel(string Name, int SecretId = 0)
        {
            if (SecretId != 0)
                this.SecretId = SecretId;

            this.Name = Name;
        }

        public SecretViewModel(string Name, int HeroId, int SecretId = 0)
        {
            if (SecretId != 0)
                this.SecretId = SecretId;

            this.Name = Name;
            this.HeroId = HeroId;
        }

        public SecretViewModel(string Name, int HeroId, Hero Hero, int SecretId = 0)
        {
            if (SecretId != 0)
                this.SecretId = SecretId;

            this.Name = Name;
            this.HeroId = HeroId;
            this.Hero = Hero;
        }
    }
}
