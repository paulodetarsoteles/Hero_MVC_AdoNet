using System.ComponentModel.DataAnnotations;

namespace Hero_MVC_AdoNet.Web.ViewModels
{
    public class HeroDropDownViewModel
    {
        [Display(Name = "Código do Herói")]
        public int? HeroId { get; set; }

        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name = "Ativo")]
        public bool Active { get; set; }


        public HeroDropDownViewModel() { }
    }
}
