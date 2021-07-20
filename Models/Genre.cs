using System.ComponentModel.DataAnnotations;

namespace asp_dotnet_webapp_MVC.Models{
    public enum Genre{
        Drama,
        Comedy,
        Romance,
        [Display(Name = "Romantic Comedy")]
        RomCom,
        Crime,
        Mystery
    }
}