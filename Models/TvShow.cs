using System;

namespace asp_dotnet_webapp_MVC.Models{
    public class TvShow{
        public int Id {get; set;}
        public string Title {get;set;}
        public Genre Genre {get;set;}
        public decimal Rating {get;set;}
        public string ImdbUrl {get;set;}
        
    }
}